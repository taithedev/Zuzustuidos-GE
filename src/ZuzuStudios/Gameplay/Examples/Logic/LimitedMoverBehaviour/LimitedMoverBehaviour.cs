using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "LimitedMoverBehaviour".</summary>
public sealed class LimitedMoverBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        if(Entity.Position.X<origin.X+4)Entity.Position+=new Vector3(2*dt,0,0);
    }
}
