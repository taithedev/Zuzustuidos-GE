# Lua API (implemented)

Each Lua script can define `start()` (called once on Play) and `update(dt)` (called every simulation frame).

| API | Meaning |
| --- | --- |
| `get_x()` / `get_y()` / `get_z()` | Entity position components |
| `get_time()` | Seconds since scripts started |
| `set_position(x, y, z)` | Replace the current position |
| `set_y(y)` | Replace vertical position |
| `translate(dx, dy, dz)` | Move the entity by delta |
| `key_down("W")` | Whether a Raylib keyboard key is held |
| `print_log(text)` | Write a short status message in the editor |

Scripts run under MoonSharp's hard sandbox. Only scripts in the project's Assets directory can be loaded. **Do not use untrusted scripts; the runtime does not enforce a CPU-time budget.**
