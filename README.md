# ZuzuStudios Game Engine

A beginner-focused **C# + Lua 3D game engine prototype** with a visual scene editor, sample project, and approachable tutorials. The repository is structured by actual features and examples rather than placeholders.

## Quick start

1. Install the free [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Clone this repository and launch `run.bat` on Windows, or `bash run.sh` on Linux/macOS.
3. Click an object in the left hierarchy, adjust transforms in the inspector, then press **Ctrl+S** to save.
4. Press **F5** to Play and use arrow keys to move the player; F5 again restores the editor state.
5. Read [Getting Started](docs/GETTING_STARTED.md) and the [48 hands-on lessons](docs/tutorials/README.md).

## What is implemented

- Resizable 3D viewport with cubes, spheres, a grid, basic object picking and fly-camera controls.
- Scene hierarchy, entity inspector, add/rename/delete/duplicate, transform editing, save/load JSON.
- Play/Stop isolation, C# `Behaviour` scripting and restricted MoonSharp Lua with `start()`/`update(dt)`.
- 96 categorized [Lua examples](examples/lua/README.md) and 24 [C# behavior examples](src/ZuzuStudios/Gameplay/Examples/README.md).
- 16 alternate demo scenes under [Scenes/Demos](projects/StarterProject/Assets/Scenes/Demos/README.md).
- Project manifest, static AABB query helper, source project validator, and GitHub Actions builds.

## Repository layout

- `src/ZuzuStudios/Core` – scenes, entities, project files
- `src/ZuzuStudios/Editor` – scene editor UI and camera
- `src/ZuzuStudios/Rendering` – primitive renderer and colors
- `src/ZuzuStudios/Scripting` – C# / Lua execution
- `src/ZuzuStudios/Gameplay` – 27 compiled game behaviours (including examples)
- `src/ZuzuStudios/Physics` – static AABB overlap queries
- `projects/StarterProject` – sample game with scenes and Lua
- `examples/lua` – 96 ready-to-copy Lua scripts
- `docs/tutorials` – 48 beginner and intermediate lessons
- `tools` – JSON validation tool

## Run and build

```sh
dotnet run --project src/ZuzuStudios/ZuzuStudios.csproj -- --project projects/StarterProject
dotnet build src/ZuzuStudios/ZuzuStudios.csproj -c Release
python tools/validate_project.py projects/StarterProject
```

Windows standalone app: `build-windows.bat` (artifacts under `dist/Windows`). Project Assets are separate files and must accompany builds; automatic game export and installers are not implemented.

## Current limitations

This is an **early prototype, not a feature-equivalent Unity replacement**. It does not currently include rigid-body simulation, mesh importing, texture authoring, animation tools, realistic lighting, audio systems, true game export packaging, multiplayer, or VR/OpenXR. The 3D objects are primitives and Lua scripts have no CPU watchdog. Use only trusted scripts and projects.

Technology: .NET 8, [Raylib-cs](https://github.com/raylib-cs/raylib-cs), [MoonSharp](https://www.moonsharp.org/).

[Architecture](docs/ARCHITECTURE.md) · [Lua API](docs/LUA_API.md) · [Roadmap](docs/ROADMAP.md) · [Contributing](CONTRIBUTING.md)

No project license has been chosen by the repository owner. Third-party dependencies retain their own licenses.
