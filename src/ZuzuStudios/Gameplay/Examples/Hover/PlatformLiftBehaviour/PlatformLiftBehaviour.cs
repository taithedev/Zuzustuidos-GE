using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "PlatformLiftBehaviour".</summary>
public sealed class PlatformLiftBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        Entity.Position = origin + new Vector3(0, MathF.Max(0,MathF.Sin(time*.6f))*2, 0);
    }
}
