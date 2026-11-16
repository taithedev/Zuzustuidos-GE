using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "PrecisionControllerBehaviour".</summary>
public sealed class PrecisionControllerBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        float d=0;
                if(Raylib.IsKeyDown(KeyboardKey.Left))d-=1;
                if(Raylib.IsKeyDown(KeyboardKey.Right))d+=1;
                Entity.Position+=new Vector3(d*.6f*dt,0,0);
    }
}
