using ZuzuStudios.Core;

namespace ZuzuStudios.Gameplay;

public abstract class Behaviour
{
    public Entity Entity { get; internal set; } = null!;
    public Scene Scene { get; internal set; } = null!;
    public virtual void OnStart() { }
    public virtual void OnUpdate(float deltaTime) { }
}
