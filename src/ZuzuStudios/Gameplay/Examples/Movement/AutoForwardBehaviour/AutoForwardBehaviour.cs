using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "AutoForwardBehaviour".</summary>
public sealed class AutoForwardBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        Entity.Position += new Vector3(0, 0, -3 * dt);
    }
}
