using Unity.Entities;

public struct GameSettingsComponent : IComponentData
{
    public float asteroidVelocity;
    public float asteroidRotation;
    public float playerForce;
    public float bulletVelocity;
    public int numAsteroids;
    public int asteroidSpawnBoxSize;
    public int levelWidth;
    public int levelHeight;
    public int levelDepth;
    public int cameraSensetivityX;
    public int cameraSensetivityY;
    public int cameraPitchMin;
    public int cameraPitchMax;
}