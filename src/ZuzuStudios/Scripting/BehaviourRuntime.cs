using ZuzuStudios.Core;
using ZuzuStudios.Gameplay;

namespace ZuzuStudios.Scripting;

public sealed class BehaviourRuntime
{
    private readonly List<Behaviour> _active = [];
    private readonly Action<string> _log;
    public BehaviourRuntime(Action<string> log) => _log = log;

    public void Start(Scene scene)
    {
        _active.Clear();
        var scripts = typeof(Behaviour).Assembly.GetTypes()
            .Where(type => typeof(Behaviour).IsAssignableFrom(type) && !type.IsAbstract)
            .ToDictionary(type => type.Name, StringComparer.OrdinalIgnoreCase);
        foreach (var entity in scene.Entities)
        {
            if (string.IsNullOrWhiteSpace(entity.CSharpScript)) continue;
            try
            {
                if (!scripts.TryGetValue(entity.CSharpScript, out var type))
                    throw new InvalidOperationException($"Unknown C# behaviour: {entity.CSharpScript}");
                var instance = (Behaviour)Activator.CreateInstance(type)!;
                instance.Entity = entity;
                instance.Scene = scene;
                instance.OnStart();
                _active.Add(instance);
            }
            catch (Exception ex) { _log("C# " + entity.Name + ": " + ex.Message); }
        }
    }

    public void Update(float dt)
    {
        foreach (var script in _active)
        {
            try { script.OnUpdate(dt); }
            catch (Exception ex) { _log("C# " + script.Entity.Name + ": " + ex.Message); }
        }
    }
}
