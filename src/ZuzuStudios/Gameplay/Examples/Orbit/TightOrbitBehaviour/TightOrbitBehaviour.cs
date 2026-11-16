using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "TightOrbitBehaviour".</summary>
public sealed class TightOrbitBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        Entity.Position = origin + new Vector3(MathF.Cos(time*2), 0, MathF.Sin(time*2));
    }
}
