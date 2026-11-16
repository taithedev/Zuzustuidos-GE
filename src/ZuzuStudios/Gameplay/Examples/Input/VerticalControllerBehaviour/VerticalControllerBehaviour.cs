using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "VerticalControllerBehaviour".</summary>
public sealed class VerticalControllerBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        float d=0;
                if(Raylib.IsKeyDown(KeyboardKey.E))d+=1;
                if(Raylib.IsKeyDown(KeyboardKey.Q))d-=1;
                Entity.Position+=new Vector3(0,d*3*dt,0);
    }
}
