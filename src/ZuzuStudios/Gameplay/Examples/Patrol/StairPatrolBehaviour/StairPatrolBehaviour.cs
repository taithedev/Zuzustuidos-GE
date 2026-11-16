using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "StairPatrolBehaviour".</summary>
public sealed class StairPatrolBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        float step=MathF.Floor(time)%5;
                Entity.Position=origin+new Vector3(step,step*.5f,0);
    }
}
