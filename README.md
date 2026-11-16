# ZuzuStudios Game Engine

A beginner-focused open-source **C# + Lua 3D game engine prototype**, including a visual scene editor, scripting runtime, example scenes, reference scripts, and tutorials.

> Status: early prototype. It does **not** yet match Unity's capabilities. This repository tracks implemented features separately from planned ones.

## Quick start

1. Install the free .NET 8 SDK.
2. Clone this repository.
3. On Windows, run `run.bat`. On other platforms, run `dotnet run --project src/ZuzuStudios/ZuzuStudios.csproj -- --project projects/StarterProject`.
4. Press **F5** to toggle Play/Stop. Press **Ctrl+S** to save.

See `docs/GETTING_STARTED.md` and `docs/tutorials` for step-by-step help.

## Working features

- 3D editor viewport with cubes, spheres, transform adjustment, hierarchy, inspector, fly camera, and scene save/load
- C# behavior classes and Lua runtime
- JSON project/scene format
- Play/Stop scene isolation
- Example game content and script library
- Windows builds through GitHub Actions

## Not included yet

Rigid-body physics, mesh importing, production materials/lighting, animation, VR, multiplayer, and deployable game exports are roadmap features, not implemented systems.

## Technology

.NET 8, Raylib-cs, MoonSharp. NuGet dependencies are restored on the first build.
