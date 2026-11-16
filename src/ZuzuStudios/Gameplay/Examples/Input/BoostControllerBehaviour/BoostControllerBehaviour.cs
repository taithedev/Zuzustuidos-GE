using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "BoostControllerBehaviour".</summary>
public sealed class BoostControllerBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        float speed=Raylib.IsKeyDown(KeyboardKey.LeftShift)?9:3;
                if(Raylib.IsKeyDown(KeyboardKey.W))Entity.Position+=new Vector3(0,0,-speed*dt);
    }
}
