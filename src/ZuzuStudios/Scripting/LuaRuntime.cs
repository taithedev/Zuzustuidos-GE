using MoonSharp.Interpreter;
using Raylib_cs;
using System.Numerics;
using ZuzuStudios.Core;

namespace ZuzuStudios.Scripting;

public sealed class LuaRuntime
{
    private readonly ProjectWorkspace _workspace;
    private readonly Action<string> _log;
    private readonly List<(Entity Entity, Script Script)> _scripts = [];
    private float _elapsed;

    public LuaRuntime(ProjectWorkspace workspace, Action<string> log)
    {
        _workspace = workspace;
        _log = log;
    }

    public void Start(Scene scene)
    {
        _scripts.Clear();
        _elapsed = 0;
        foreach (var entity in scene.Entities)
        {
            if (string.IsNullOrWhiteSpace(entity.LuaScript)) continue;
            try
            {
                var script = new Script(CoreModules.Preset_HardSandbox);
                Bind(script, entity);
                string file = _workspace.ResolveAsset(entity.LuaScript);
                script.DoString(File.ReadAllText(file), null, file);
                var start = script.Globals.Get("start");
                if (start.Type == DataType.Function) script.Call(start);
                _scripts.Add((entity, script));
            }
            catch (Exception ex) { _log("Lua " + entity.Name + ": " + ex.Message); }
        }
    }

    public void Update(float dt)
    {
        _elapsed += dt;
        foreach (var item in _scripts)
        {
            try
            {
                var fn = item.Script.Globals.Get("update");
                if (fn.Type == DataType.Function) item.Script.Call(fn, dt);
            }
            catch (Exception ex) { _log("Lua " + item.Entity.Name + ": " + ex.Message); }
        }
    }

    private void Bind(Script lua, Entity entity)
    {
        lua.Globals["get_x"] = DynValue.NewCallback((_, _) => DynValue.NewNumber(entity.Position.X));
        lua.Globals["get_y"] = DynValue.NewCallback((_, _) => DynValue.NewNumber(entity.Position.Y));
        lua.Globals["get_z"] = DynValue.NewCallback((_, _) => DynValue.NewNumber(entity.Position.Z));
        lua.Globals["get_time"] = DynValue.NewCallback((_, _) => DynValue.NewNumber(_elapsed));
        lua.Globals["set_position"] = DynValue.NewCallback((_, args) =>
        {
            entity.Position = new Vector3((float)args[0].Number, (float)args[1].Number, (float)args[2].Number);
            return DynValue.Nil;
        });
        lua.Globals["set_y"] = DynValue.NewCallback((_, args) =>
        {
            var p = entity.Position;
            p.Y = (float)args[0].Number;
            entity.Position = p;
            return DynValue.Nil;
        });
        lua.Globals["translate"] = DynValue.NewCallback((_, args) =>
        {
            entity.Position += new Vector3((float)args[0].Number, (float)args[1].Number, (float)args[2].Number);
            return DynValue.Nil;
        });
        lua.Globals["key_down"] = DynValue.NewCallback((_, args) =>
        {
            var name = args[0].CastToString();
            bool held = Enum.TryParse<KeyboardKey>(name, true, out var key) && Raylib.IsKeyDown(key);
            return DynValue.NewBoolean(held);
        });
        lua.Globals["print_log"] = DynValue.NewCallback((_, args) =>
        {
            _log("Lua: " + args[0].CastToString());
            return DynValue.Nil;
        });
    }
}
