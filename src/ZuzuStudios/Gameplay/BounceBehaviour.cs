namespace ZuzuStudios.Gameplay;

public sealed class BounceBehaviour : Behaviour
{
    private float _time;
    private float _baseline;
    public float Height { get; set; } = .5f;
    public override void OnStart() => _baseline = Entity.Position.Y;
    public override void OnUpdate(float deltaTime)
    {
        _time += deltaTime;
        var p = Entity.Position;
        p.Y = _baseline + MathF.Abs(MathF.Sin(_time * 2.5f)) * Height;
        Entity.Position = p;
    }
}
