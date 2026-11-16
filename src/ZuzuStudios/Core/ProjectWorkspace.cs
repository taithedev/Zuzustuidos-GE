using System.Text.Json;
using ZuzuStudios.Serialization;

namespace ZuzuStudios.Core;

public sealed class ProjectWorkspace
{
    public string Root { get; }
    public string AssetsRoot => Path.Combine(Root, "Assets");
    public ProjectManifest Manifest { get; }
    public string ScenePath => ResolveAsset(Manifest.StartupScene);

    private ProjectWorkspace(string root, ProjectManifest manifest)
    {
        Root = Path.GetFullPath(root);
        Manifest = manifest;
    }

    public static ProjectWorkspace Open(string? root)
    {
        root = root is not null ? Path.GetFullPath(root) : DiscoverDefault();
        var config = Path.Combine(root, "project.json");
        if (!File.Exists(config))
            throw new FileNotFoundException("Missing project.json. Use --project <folder>.", config);
        var manifest = JsonSerializer.Deserialize<ProjectManifest>(File.ReadAllText(config),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new InvalidDataException("Invalid project.json.");
        var workspace = new ProjectWorkspace(root, manifest);
        _ = workspace.ResolveAsset(manifest.StartupScene);
        return workspace;
    }

    public Scene LoadScene() => SceneSerializer.Load(ScenePath);
    public void SaveScene(Scene scene) => SceneSerializer.Save(scene, ScenePath);

    public string ResolveAsset(string relative)
    {
        if (string.IsNullOrWhiteSpace(relative)) throw new ArgumentException("Empty asset path.");
        var baseDir = Path.GetFullPath(AssetsRoot);
        var absolute = Path.GetFullPath(Path.Combine(baseDir, relative));
        if (!absolute.StartsWith(baseDir + Path.DirectorySeparatorChar,
                OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
            throw new InvalidOperationException("Assets must stay within the project Assets folder.");
        return absolute;
    }

    private static string DiscoverDefault()
    {
        foreach (string start in new[] { Environment.CurrentDirectory, AppContext.BaseDirectory })
        {
            for (var current = new DirectoryInfo(start); current is not null; current = current.Parent)
            {
                var candidate = Path.Combine(current.FullName, "projects", "StarterProject", "project.json");
                if (File.Exists(candidate)) return Path.GetDirectoryName(candidate)!;
            }
        }
        throw new DirectoryNotFoundException("No project found. Start the editor from the repository root.");
    }
}
