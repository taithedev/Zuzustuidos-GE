# Get started in 5 minutes

1. Install the free **.NET 8 SDK** (not just the .NET runtime).
2. Run `run.bat` on Windows, or `bash run.sh` on Linux/macOS.
3. Wait for NuGet to download Raylib-cs and MoonSharp. An editor window opens.
4. In the left hierarchy click an entity. Press the + and - inspector buttons to adjust Position and Size.
5. Add more cubes/spheres with toolbar buttons. Press Ctrl+S to save.
6. Press F5 to simulate. The player cube responds to Arrow keys. Press F5 to stop.
7. Modify `projects/StarterProject/Assets/Scripts/floating.lua`, then start Play again to reload.

You can edit `project.json` to change the window size and target FPS. More tutorials are inside `docs/tutorials/`.

**Important:** C# behavior files belong inside `src/ZuzuStudios` and require recompiling. Lua files in a project's Assets/Scripts folder load when Play starts. This is an early engine prototype, not a Unity replacement.
