using System.Numerics;

namespace ZuzuStudios.Gameplay;

public sealed class OrbitBehaviour : Behaviour
{
    private float _angle;
    private Vector3 _center;
    public float Radius { get; set; } = 2f;
    public float AngularSpeed { get; set; } = 1.25f;
    public override void OnStart() { _center = Entity.Position; }
    public override void OnUpdate(float deltaTime)
    {
        _angle += deltaTime * AngularSpeed;
        Entity.Position = _center + new Vector3(MathF.Cos(_angle) * Radius, 0, MathF.Sin(_angle) * Radius);
    }
}
