namespace ZuzuStudios.Core;

public sealed class ProjectManifest
{
    public string Name { get; set; } = "Zuzu Game";
    public string StartupScene { get; set; } = "Scenes/main.scene.json";
    public int WindowWidth { get; set; } = 1400;
    public int WindowHeight { get; set; } = 840;
    public int TargetFps { get; set; } = 120;
}
