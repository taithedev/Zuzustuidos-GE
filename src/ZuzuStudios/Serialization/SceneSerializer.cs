using System.Text.Json;
using ZuzuStudios.Core;

namespace ZuzuStudios.Serialization;

public static class SceneSerializer
{
    public static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true, IncludeFields = true, PropertyNameCaseInsensitive = true
    };

    public static Scene Load(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("Scene file not found", path);
        var scene = JsonSerializer.Deserialize<Scene>(File.ReadAllText(path), Options)
            ?? throw new InvalidDataException("Scene is empty.");
        scene.Entities ??= [];
        foreach (var entity in scene.Entities)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
            entity.Name ??= "Entity";
        }
        return scene;
    }

    public static void Save(Scene scene, string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var temp = path + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(scene, Options));
        File.Move(temp, path, overwrite: true);
    }

    public static Scene Clone(Scene scene) =>
        JsonSerializer.Deserialize<Scene>(JsonSerializer.Serialize(scene, Options), Options)!;
}
