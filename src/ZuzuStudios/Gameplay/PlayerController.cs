using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

public sealed class PlayerController : Behaviour
{
    public float Speed { get; set; } = 4.5f;

    public override void OnUpdate(float dt)
    {
        var direction = Vector3.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.Left)) direction.X -= 1;
        if (Raylib.IsKeyDown(KeyboardKey.Right)) direction.X += 1;
        if (Raylib.IsKeyDown(KeyboardKey.Up)) direction.Z -= 1;
        if (Raylib.IsKeyDown(KeyboardKey.Down)) direction.Z += 1;
        if (direction.LengthSquared() > 0) Entity.Position += Vector3.Normalize(direction) * Speed * dt;
    }
}
