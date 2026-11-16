using System.Numerics;
using Raylib_cs;
using ZuzuStudios.Core;
using ZuzuStudios.Rendering;
using ZuzuStudios.Scripting;

namespace ZuzuStudios.Editor;

/// <summary>Immediate-mode visual editor. Keeps the edit scene isolated from Play mode.</summary>
public sealed class EditorApplication
{
    private const int Top = 58, Left = 235, Right = 286, Bottom = 32;
    private readonly ProjectWorkspace _project;
    private readonly FlyCamera _camera = new();
    private readonly bool _gameOnly;
    private Scene _scene;
    private Scene? _beforePlay;
    private ScriptRuntime? _scripts;
    private Guid? _selected;
    private bool _playing, _grid = true, _help = true, _rename;
    private string _typedName = "";
    private string _status = "Ready. Press F1 for help.";

    public EditorApplication(ProjectWorkspace project, bool gameOnly = false)
    {
        _project = project;
        _scene = project.LoadScene();
        _gameOnly = gameOnly;
        _selected = _scene.Entities.FirstOrDefault()?.Id;
    }

    private Entity? Selected => _selected is Guid id ? _scene.Find(id) : null;
    private int W => Raylib.GetScreenWidth();
    private int H => Raylib.GetScreenHeight();
    private bool Viewport(Vector2 mouse) => _gameOnly || (mouse.X > Left &&
        mouse.X < W - Right && mouse.Y > Top && mouse.Y < H - Bottom);

    public void Run()
    {
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.Msaa4xHint);
        Raylib.InitWindow(Math.Max(960, _project.Manifest.WindowWidth),
            Math.Max(640, _project.Manifest.WindowHeight), "ZuzuStudios | " + _project.Manifest.Name);
        Raylib.SetTargetFPS(Math.Clamp(_project.Manifest.TargetFps, 30, 240));
        if (_gameOnly) StartPlay();
        try
        {
            while (!Raylib.WindowShouldClose())
            {
                float dt = Math.Clamp(Raylib.GetFrameTime(), 0, .1f);
                ProcessInput(dt);
                if (_playing) _scripts?.Update(dt);
                Raylib.BeginDrawing();
                Raylib.ClearBackground(ColorPalette.Background);
                SceneRenderer.Draw(_scene, _camera.Camera, _playing ? null : _selected, _grid);
                if (!_gameOnly) DrawUi();
                Raylib.EndDrawing();
            }
        }
        finally { Raylib.CloseWindow(); }
    }

    private void ProcessInput(float dt)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.F1)) _help = !_help;
        if (!_gameOnly && Raylib.IsKeyPressed(KeyboardKey.F5)) TogglePlay();
        if (_playing)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.F6)) ReloadScripts();
            return;
        }
        if (_rename)
        {
            int point;
            while ((point = Raylib.GetCharPressed()) != 0)
                if (point >= 32 && _typedName.Length < 40) _typedName += char.ConvertFromUtf32(point);
            if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && _typedName.Length > 0)
                _typedName = _typedName[..^1];
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                if (Selected is not null && !string.IsNullOrWhiteSpace(_typedName))
                    Selected.Name = _typedName.Trim();
                _rename = false;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Escape)) _rename = false;
            return;
        }
        bool ctrl = Raylib.IsKeyDown(KeyboardKey.LeftControl) || Raylib.IsKeyDown(KeyboardKey.RightControl);
        if (ctrl && Raylib.IsKeyPressed(KeyboardKey.S)) Save();
        if (ctrl && Raylib.IsKeyPressed(KeyboardKey.D)) Duplicate();
        if (Raylib.IsKeyPressed(KeyboardKey.G)) _grid = !_grid;
        if (Raylib.IsKeyPressed(KeyboardKey.F2) && Selected is not null) BeginRename();
        if (Raylib.IsKeyPressed(KeyboardKey.Delete)) Delete();
        if (Raylib.IsKeyPressed(KeyboardKey.Insert))
            Add(Raylib.IsKeyDown(KeyboardKey.LeftShift) ? "Sphere" : "Cube");
        var pointer = Raylib.GetMousePosition();
        _camera.Update(dt, Viewport(pointer));
        if (Viewport(pointer) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            _selected = SelectionPicker.Pick(_scene, _camera.Camera, pointer) ?? _selected;
        if (Selected is not null && !Raylib.IsMouseButtonDown(MouseButton.Right))
        {
            var delta = Vector3.Zero;
            if (Raylib.IsKeyPressed(KeyboardKey.Left)) delta.X -= .25f;
            if (Raylib.IsKeyPressed(KeyboardKey.Right)) delta.X += .25f;
            if (Raylib.IsKeyPressed(KeyboardKey.Up)) delta.Z -= .25f;
            if (Raylib.IsKeyPressed(KeyboardKey.Down)) delta.Z += .25f;
            if (Raylib.IsKeyPressed(KeyboardKey.PageUp)) delta.Y += .25f;
            if (Raylib.IsKeyPressed(KeyboardKey.PageDown)) delta.Y -= .25f;
            Selected.Position += delta;
        }
    }

    private void DrawUi()
    {
        Raylib.DrawRectangle(0, 0, W, Top, ColorPalette.Panel);
        UiWidgets.Label("ZuzuStudios", 17, 14, 25);
        UiWidgets.Label("GAME ENGINE  /  EARLY ACCESS", 19, 40, 10, true);
        int x = 245;
        if (UiWidgets.Button("+ Cube", x, 13, 84, 33)) Add("Cube"); x += 90;
        if (UiWidgets.Button("+ Sphere", x, 13, 94, 33)) Add("Sphere"); x += 100;
        if (UiWidgets.Button("Duplicate", x, 13, 91, 33)) Duplicate(); x += 97;
        if (UiWidgets.Button("Save", x, 13, 78, 33)) Save(); x += 84;
        if (UiWidgets.Button(_playing ? "Stop" : "Play", x, 13, 80, 33, _playing)) TogglePlay(); x += 86;
        if (UiWidgets.Button("Reload", x, 13, 80, 33)) ReloadScripts();
        UiWidgets.Label(Raylib.GetFPS() + " FPS", W - 90, 24, 15, true);

        Raylib.DrawRectangle(0, Top, Left, H - Top - Bottom, ColorPalette.Panel);
        UiWidgets.Label("HIERARCHY", 18, Top + 19, 16);
        UiWidgets.Label(Short(_scene.Name, 27), 18, Top + 44, 12, true);
        int row = Top + 79;
        foreach (var entity in _scene.Entities)
        {
            if (row > H - 100) break;
            if (UiWidgets.Button(Short(entity.Name, 25), 12, row, Left - 24, 34, entity.Id == _selected))
                _selected = entity.Id;
            row += 40;
        }
        UiWidgets.Label("Insert: add | F2: rename", 14, H - 77, 12, true);
        UiWidgets.Label("Ctrl+D: duplicate | Delete", 14, H - 57, 12, true);

        int inspector = W - Right;
        Raylib.DrawRectangle(inspector, Top, Right, H - Top - Bottom, ColorPalette.Panel);
        UiWidgets.Label("INSPECTOR", inspector + 17, Top + 19, 16);
        DrawInspector(inspector + 17, Top + 67);

        Raylib.DrawRectangle(0, H - Bottom, W, Bottom, ColorPalette.Panel);
        UiWidgets.Label(Short(_status, Math.Max(35, W / 11)), 12, H - 24, 13, true);
        UiWidgets.Label("F1 HELP | F5 PLAY | CTRL+S SAVE", W - 290, H - 24, 12, true);

        if (_help) DrawHelp();
        if (_rename)
        {
            int middle = W / 2 - 220;
            Raylib.DrawRectangle(middle, H / 2 - 58, 440, 116, ColorPalette.Panel);
            Raylib.DrawRectangleLines(middle, H / 2 - 58, 440, 116, ColorPalette.Accent);
            UiWidgets.Label("RENAME ENTITY", middle + 18, H / 2 - 40, 17);
            UiWidgets.Label(_typedName + "_", middle + 18, H / 2 - 4, 21);
            UiWidgets.Label("Enter to save / Esc to cancel", middle + 18, H / 2 + 35, 13, true);
        }
    }

    private void DrawInspector(int x, int y)
    {
        if (_playing) { UiWidgets.Label("Stop to edit objects.", x, y, 14, true); return; }
        var entity = Selected;
        if (entity is null) { UiWidgets.Label("Select a scene object.", x, y, 14, true); return; }
        UiWidgets.Label(Short(entity.Name, 24), x, y, 19); y += 34;
        if (UiWidgets.Button("Rename", x, y, 115, 31)) BeginRename();
        if (UiWidgets.Button("Delete", x + 123, y, 115, 31)) Delete(); y += 51;
        UiWidgets.Label("POSITION", x, y, 15); y += 25;
        var p = entity.Position;
        p.X = Axis(x, y, "X", p.X); y += 39;
        p.Y = Axis(x, y, "Y", p.Y); y += 39;
        p.Z = Axis(x, y, "Z", p.Z); y += 50;
        entity.Position = p;
        UiWidgets.Label("SIZE", x, y, 15); y += 25;
        var s = entity.Size;
        s.X = Math.Max(.1f, Axis(x, y, "X", s.X)); y += 39;
        s.Y = Math.Max(.1f, Axis(x, y, "Y", s.Y)); y += 39;
        s.Z = Math.Max(.1f, Axis(x, y, "Z", s.Z)); y += 50;
        entity.Size = s;
        UiWidgets.Label("LUA SCRIPT", x, y, 14); y += 22;
        UiWidgets.Label(Short(entity.LuaScript ?? "(none)", 29), x, y, 12, true); y += 22;
        if (UiWidgets.Button(entity.LuaScript is null ? "+ Attach Lua" : "Remove Lua", x, y, 238, 30))
            entity.LuaScript = entity.LuaScript is null ? "Scripts/floating.lua" : null;
        y += 48;
        UiWidgets.Label("C# BEHAVIOUR", x, y, 14); y += 22;
        UiWidgets.Label(Short(entity.CSharpScript ?? "(none)", 29), x, y, 12, true); y += 22;
        if (UiWidgets.Button(entity.CSharpScript is null ? "+ Attach C#" : "Remove C#", x, y, 238, 30))
            entity.CSharpScript = entity.CSharpScript is null ? "PlayerController" : null;
    }

    private static float Axis(int x, int y, string label, float val)
    {
        UiWidgets.Label(label, x, y + 8);
        UiWidgets.Label(val.ToString("0.00"), x + 35, y + 8, 15, true);
        if (UiWidgets.Button("-", x + 146, y, 42, 30)) val -= .25f;
        if (UiWidgets.Button("+", x + 195, y, 42, 30)) val += .25f;
        return MathF.Round(val, 2);
    }

    private void DrawHelp()
    {
        int width = Math.Min(620, W - Left - Right - 50);
        if (width < 350 || H < 560) return;
        int x = Left + 24, y = H - 260;
        Raylib.DrawRectangle(x, y, width, 206, ColorPalette.Panel);
        UiWidgets.Label("START HERE (F1 HIDE)", x + 17, y + 14, 20);
        string[] lines =
        [
            "1. Click + Cube or + Sphere to add objects.",
            "2. Select in Hierarchy; change position/size in Inspector.",
            "3. Ctrl+S saves the JSON scene to your project.",
            "4. F5 starts Play. Stop restores the original editor scene.",
            "5. Camera: hold right mouse + WASD / Q / E; mouse wheel zoom.",
            "6. F6 reloads Lua on Play. See docs for scripting."
        ];
        for (int i = 0; i < lines.Length; i++)
            UiWidgets.Label(lines[i], x + 17, y + 48 + i * 25, 14, i > 3);
    }

    private void Add(string primitive)
    {
        if (_playing) return;
        var entity = _scene.Add(primitive);
        _selected = entity.Id;
        _status = "Added " + entity.Name + ". Ctrl+S to save.";
    }

    private void Duplicate()
    {
        if (_playing || Selected is null) return;
        var src = Selected;
        var clone = new Entity
        {
            Name = src.Name + " Copy", Primitive = src.Primitive,
            Position = src.Position + Vector3.UnitX, Size = src.Size,
            Color = src.Color, LuaScript = src.LuaScript,
            CSharpScript = src.CSharpScript, Visible = src.Visible
        };
        _scene.Entities.Add(clone);
        _selected = clone.Id;
        _status = "Duplicated " + src.Name;
    }

    private void Delete()
    {
        if (_playing || Selected is null) return;
        _status = "Deleted " + Selected.Name;
        _scene.Remove(Selected.Id);
        _selected = _scene.Entities.FirstOrDefault()?.Id;
    }

    private void BeginRename()
    {
        if (_playing || Selected is null) return;
        _typedName = Selected.Name;
        _rename = true;
    }

    private void Save()
    {
        if (_playing) { _status = "Stop playback before saving."; return; }
        try { _project.SaveScene(_scene); _status = "Scene saved."; }
        catch (Exception ex) { _status = "Save error: " + ex.Message; }
    }

    private void TogglePlay() { if (_playing) StopPlay(); else StartPlay(); }

    private void StartPlay()
    {
        if (_playing) return;
        _beforePlay = _scene;
        _scene = _scene.Snapshot();
        _scripts = new ScriptRuntime(_project, msg => _status = Short(msg, 100));
        _scripts.Start(_scene);
        _playing = true;
        _status = "Playing. Arrow keys move the player; F5 stops.";
    }

    private void StopPlay()
    {
        if (!_playing) return;
        _playing = false;
        _scripts = null;
        _scene = _beforePlay ?? _scene;
        _beforePlay = null;
        _status = "Edit mode: Play changes discarded.";
    }

    private void ReloadScripts()
    {
        if (!_playing || _scripts is null) { _status = "Start Play first."; return; }
        _scripts.Start(_scene);
        _status = "Scripts reloaded.";
    }

    private static string Short(string s, int max) =>
        s.Length > max && max > 4 ? s[..(max - 3)] + "..." : s;
}
