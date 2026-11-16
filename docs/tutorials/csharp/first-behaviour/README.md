# Create your first C# behavior

**Lesson 2 / csharp**

## Goal

Create a .cs file inside src/ZuzuStudios/Gameplay, declare namespace ZuzuStudios.Gameplay and inherit Behaviour.

## Try it

```text
public sealed class MyMove : Behaviour {
    public override void OnUpdate(float dt) {
        Entity.Position += new System.Numerics.Vector3(0,dt,0);
    }
}
```

## What to know

Rebuild the C# engine, then attach CSharpScript: MyMove to an entity.

## Continue

Go back to the [tutorial index](../../README.md) and choose another lesson, or try an [example Lua script](../../../../examples/lua/README.md).
