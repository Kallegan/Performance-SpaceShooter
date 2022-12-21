using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SetGameSettingsSystem : UnityEngine.MonoBehaviour, IConvertGameObjectToEntity
{
    public float asteroidVelocity = 10f;
    public float asteroidRotation = 1f;
    public float playerForce = 50f;
    public float bulletVelocity = 500f;    
    public int numAsteroids = 200;   
    public int levelWidth = 2048;
    public int levelHeight = 2048;
    public int levelDepth = 2048;
    public int cameraSensetivityX = 2;
    public int cameraSensetivityY = 2;
    public int cameraPitchMin = 90;
    public int cameraPitchMax = 270;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var settings = default(GameSettingsComponent);

        settings.asteroidVelocity = asteroidVelocity;
        settings.asteroidRotation = asteroidRotation;
        settings.playerForce = playerForce;
        settings.bulletVelocity = bulletVelocity;
        settings.numAsteroids = numAsteroids;
        settings.levelWidth = levelWidth;
        settings.levelHeight = levelHeight;
        settings.levelDepth = levelDepth;
        settings.cameraSensetivityX = cameraSensetivityX;
        settings.cameraSensetivityY = cameraSensetivityY;
        settings.cameraPitchMin = cameraPitchMin;
        settings.cameraPitchMax = cameraPitchMax;

        dstManager.AddComponentData(entity, settings);
    }
}