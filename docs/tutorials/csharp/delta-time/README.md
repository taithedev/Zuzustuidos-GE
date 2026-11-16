# Use delta time in C#

**Lesson 4 / csharp**

## Goal

The engine calls OnUpdate(deltaTime) during Play mode.

## Try it

```text
Entity.Position += new System.Numerics.Vector3(0, 2 * dt, 0);
```

## What to know

The dt argument is clamped to 0.1 seconds for stability.

## Continue

Go back to the [tutorial index](../../../README.md) and choose another lesson, or try an [example Lua script](../../../../../examples/lua/README.md).
