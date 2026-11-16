using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "PulseMoverBehaviour".</summary>
public sealed class PulseMoverBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        if(((int)time)%2==0)Entity.Position+=new Vector3(0,dt*2,0);
    }
}
