using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "WrapMoverBehaviour".</summary>
public sealed class WrapMoverBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        var p=Entity.Position;
                p.Z-=3*dt;
                if(p.Z<origin.Z-7)p.Z=origin.Z;
                Entity.Position=p;
    }
}
