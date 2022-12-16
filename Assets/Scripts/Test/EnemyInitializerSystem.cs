using Unity.Entities;

[GenerateAuthoringComponent]
public class EnemyInitializerSystem : IComponentData
{
    public int xGridCount;
    public int zGridCount;
    public float baseOffset;
    public float xPadding;
    public float yPadding;
    public Entity prefabToSpawn;
}
