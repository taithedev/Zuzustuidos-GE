using ZuzuStudios.Core;

namespace ZuzuStudios.Scripting;

public sealed class ScriptRuntime
{
    private readonly BehaviourRuntime _behaviours;
    private readonly LuaRuntime _lua;

    public ScriptRuntime(ProjectWorkspace workspace, Action<string> log)
    {
        _behaviours = new BehaviourRuntime(log);
        _lua = new LuaRuntime(workspace, log);
    }

    public void Start(Scene scene)
    {
        _behaviours.Start(scene);
        _lua.Start(scene);
    }

    public void Update(float deltaTime)
    {
        var dt = Math.Clamp(deltaTime, 0, .1f);
        _behaviours.Update(dt);
        _lua.Update(dt);
    }
}
