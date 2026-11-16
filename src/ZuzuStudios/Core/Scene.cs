namespace ZuzuStudios.Core;

public sealed class Scene
{
    public string Name { get; set; } = "Untitled Scene";
    public List<Entity> Entities { get; set; } = [];

    public Entity Add(string primitive = "Cube")
    {
        var entity = new Entity
        {
            Name = primitive + " " + (Entities.Count + 1),
            Primitive = primitive,
            Color = primitive.Equals("Sphere", StringComparison.OrdinalIgnoreCase) ? "#D9AAFF" : "#65C9FF"
        };
        Entities.Add(entity);
        return entity;
    }

    public Entity? Find(Guid id) => Entities.FirstOrDefault(e => e.Id == id);
    public bool Remove(Guid id) => Entities.RemoveAll(e => e.Id == id) > 0;
    public Scene Snapshot() => Serialization.SceneSerializer.Clone(this);
}
