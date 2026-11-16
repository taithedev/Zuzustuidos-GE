using System.Numerics;
using Raylib_cs;

namespace ZuzuStudios.Gameplay;

/// <summary>Example C# behaviour. Set an entity's CSharpScript to "WasdControllerBehaviour".</summary>
public sealed class WasdControllerBehaviour : Behaviour
{
    private float time;
    private Vector3 origin;
    public override void OnStart() => origin = Entity.Position;
    public override void OnUpdate(float dt)
    {
        time += dt;
        var v=Vector3.Zero;
                if(Raylib.IsKeyDown(KeyboardKey.W))v.Z-=1;
                if(Raylib.IsKeyDown(KeyboardKey.S))v.Z+=1;
                if(Raylib.IsKeyDown(KeyboardKey.A))v.X-=1;
                if(Raylib.IsKeyDown(KeyboardKey.D))v.X+=1;
                if(v.LengthSquared()>0)Entity.Position+=Vector3.Normalize(v)*3*dt;
    }
}
