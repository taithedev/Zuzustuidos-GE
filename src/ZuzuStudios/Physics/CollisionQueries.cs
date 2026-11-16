using System.Numerics;
using ZuzuStudios.Core;

namespace ZuzuStudios.Physics;

/// <summary>Static bounding-box queries, not a rigid-body physics simulator.</summary>
public static class CollisionQueries
{
    public static bool Overlaps(Entity a, Entity b)
    {
        var d = Vector3.Abs(a.Position - b.Position);
        var half = (Vector3.Abs(a.Size) + Vector3.Abs(b.Size)) * .5f;
        return d.X <= half.X && d.Y <= half.Y && d.Z <= half.Z;
    }

    public static bool PointInside(Entity entity, Vector3 point)
    {
        var delta = Vector3.Abs(point - entity.Position);
        var radius = Vector3.Abs(entity.Size) * .5f;
        return delta.X <= radius.X && delta.Y <= radius.Y && delta.Z <= radius.Z;
    }
}
