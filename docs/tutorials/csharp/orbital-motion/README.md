# Create orbital motion

**Lesson 5 / csharp**

## Goal

Use MathF.Sin and MathF.Cos with elapsed time to move a primitive along a circular route.

## Try it

```text
Entity.Position = origin + new System.Numerics.Vector3(MathF.Cos(t)*2, 0, MathF.Sin(t)*2);
```

## What to know

See OrbitBehaviour.cs for the complete working example including OnStart and state.

## Continue

Go back to the [tutorial index](../../../README.md) and choose another lesson, or try an [example Lua script](../../../../../examples/lua/README.md).
