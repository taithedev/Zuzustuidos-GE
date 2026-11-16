using System.Numerics;
using Raylib_cs;
using ZuzuStudios.Core;

namespace ZuzuStudios.Rendering;

public static class SceneRenderer
{
    public static void Draw(Scene scene, Camera3D camera, Guid? selected, bool grid)
    {
        Raylib.BeginMode3D(camera);
        if (grid) Raylib.DrawGrid(40, 1f);
        foreach (var entity in scene.Entities.Where(e => e.Visible))
        {
            var tint = ColorPalette.Parse(entity.Color);
            if (entity.Primitive.Equals("Sphere", StringComparison.OrdinalIgnoreCase))
            {
                float radius = Math.Max(.05f, entity.Size.X * .5f);
                Raylib.DrawSphere(entity.Position, radius, tint);
                if (entity.Id == selected)
                    Raylib.DrawSphereWires(entity.Position, radius + .03f, 12, 16, ColorPalette.Accent);
            }
            else
            {
                var size = Vector3.Max(entity.Size, new Vector3(.05f));
                Raylib.DrawCubeV(entity.Position, size, tint);
                if (entity.Id == selected)
                    Raylib.DrawCubeWiresV(entity.Position, size + new Vector3(.07f), ColorPalette.Accent);
            }
        }
        Raylib.EndMode3D();
    }
}
