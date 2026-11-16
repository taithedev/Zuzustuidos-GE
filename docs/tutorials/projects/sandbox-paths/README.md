# Keep assets inside the project

**Lesson 4 / projects**

## Goal

All resolved assets must be descendants of the project's Assets folder.

## Try it

```text
"LuaScript": "Scripts/keyboard_move.lua"
```

## What to know

Parent-directory traversal is blocked for script paths. This is a path check, not a guarantee that untrusted Lua is safe.

## Continue

Go back to the [tutorial index](../../../README.md) and choose another lesson, or try an [example Lua script](../../../../../examples/lua/README.md).
