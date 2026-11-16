using System.Numerics;
using Raylib_cs;
using ZuzuStudios.Core;

namespace ZuzuStudios.Editor;

public static class SelectionPicker
{
    public static Guid? Pick(Scene scene, Camera3D camera, Vector2 screenPoint)
    {
        var ray = Raylib.GetScreenToWorldRay(screenPoint, camera);
        float distance = float.PositiveInfinity;
        Guid? selected = null;
        foreach (var entity in scene.Entities.Where(e => e.Visible))
        {
            var half = Vector3.Max(entity.Size, new Vector3(.05f)) / 2;
            var collision = Raylib.GetRayCollisionBox(ray,
                new BoundingBox(entity.Position - half, entity.Position + half));
            if (!collision.Hit || collision.Distance >= distance) continue;
            distance = collision.Distance;
            selected = entity.Id;
        }
        return selected;
    }
}
