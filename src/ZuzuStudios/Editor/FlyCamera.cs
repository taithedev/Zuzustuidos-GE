using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Editor;

public sealed class FlyCamera
{
    private float _yaw = -2.4f;
    private float _pitch = -.4f;
    public Camera3D Camera = new(new Vector3(10, 8, 10), Vector3.Zero, Vector3.UnitY, 55,
        CameraProjection.Perspective);

    public void Update(float dt, bool enabled)
    {
        if (!enabled) return;
        float wheel = Raylib.GetMouseWheelMove();
        if (wheel != 0)
        {
            var direction = Camera.Target - Camera.Position;
            if (direction.LengthSquared() > .001f)
                Camera.Position += Vector3.Normalize(direction) * wheel;
        }
        if (!Raylib.IsMouseButtonDown(MouseButton.Right)) return;
        var m = Raylib.GetMouseDelta();
        _yaw -= m.X * .005f;
        _pitch = Math.Clamp(_pitch - m.Y * .005f, -1.4f, 1.4f);
        var forward = new Vector3(MathF.Cos(_pitch) * MathF.Sin(_yaw),
            MathF.Sin(_pitch), MathF.Cos(_pitch) * MathF.Cos(_yaw));
        var flat = Vector3.Normalize(new Vector3(forward.X, 0, forward.Z));
        var right = Vector3.Normalize(Vector3.Cross(flat, Vector3.UnitY));
        float speed = dt * (Raylib.IsKeyDown(KeyboardKey.LeftShift) ? 16 : 8);
        if (Raylib.IsKeyDown(KeyboardKey.W)) Camera.Position += flat * speed;
        if (Raylib.IsKeyDown(KeyboardKey.S)) Camera.Position -= flat * speed;
        if (Raylib.IsKeyDown(KeyboardKey.A)) Camera.Position -= right * speed;
        if (Raylib.IsKeyDown(KeyboardKey.D)) Camera.Position += right * speed;
        if (Raylib.IsKeyDown(KeyboardKey.E)) Camera.Position += Vector3.UnitY * speed;
        if (Raylib.IsKeyDown(KeyboardKey.Q)) Camera.Position -= Vector3.UnitY * speed;
        Camera.Target = Camera.Position + forward;
    }
}
