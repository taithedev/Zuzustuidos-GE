using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "RampMoverBehaviour".</summary>
public sealed class RampMoverBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        float speed=MathF.Min(5,time);
                Entity.Position+=new Vector3(0,0,-speed*dt);
    }
}
