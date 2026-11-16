using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "VerticalOrbitBehaviour".</summary>
public sealed class VerticalOrbitBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        Entity.Position = origin + new Vector3(0, MathF.Cos(time)*2, MathF.Sin(time)*2);
    }
}
