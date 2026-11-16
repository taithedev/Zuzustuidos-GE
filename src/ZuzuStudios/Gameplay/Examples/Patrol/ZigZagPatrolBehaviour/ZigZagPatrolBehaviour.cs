using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "ZigZagPatrolBehaviour".</summary>
public sealed class ZigZagPatrolBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        Entity.Position=origin+new Vector3(MathF.Sin(time*3),0,(time*.6f)%6);
    }
}
