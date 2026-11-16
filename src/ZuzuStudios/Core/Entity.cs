using System.Numerics;

namespace ZuzuStudios.Core;

/// <summary>A scene object backed by a serializable transform and optional scripts.</summary>
public sealed class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "Entity";
    public string Primitive { get; set; } = "Cube";
    public Vector3 Position { get; set; } = new(0, 1, 0);
    public Vector3 Size { get; set; } = Vector3.One;
    public string Color { get; set; } = "#65C9FF";
    public bool Visible { get; set; } = true;
    public string? LuaScript { get; set; }
    public string? CSharpScript { get; set; }
}
