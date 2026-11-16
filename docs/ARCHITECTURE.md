# Architecture

- `Core`: project paths, scene model and serialized entities
- `Serialization`: JSON load/save and Play-mode cloning
- `Rendering`: primitive-based 3D scene renderer
- `Editor`: Raylib immediate-mode UI, selection and camera
- `Gameplay`: C# behaviours compiled into the editor
- `Scripting`: MoonSharp sandboxed Lua callback bridge and C# lifecycle
- `Physics`: simple AABB query helpers (not real rigid-body physics)
- `Diagnostics`: basic frame timer
- `projects/StarterProject`: assets owned by the sample game

The C# runtime discovers Behaviour subclasses from its compiled assembly. The Lua bridge exposes only `get_x`, `get_y`, `get_z`, `get_time`, `set_position`, `set_y`, `translate`, `key_down` and `print_log`.

The project loads JSON scene data from the project manifest, creates an in-memory clone on Play, runs scripts against the clone, and restores the editable scene when stopping.
