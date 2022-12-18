using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public partial class AsteroidRotationSystem : SystemBase
{
    protected override void OnCreate()
    {
        //We will use playerForce from the GameSettingsComponent to adjust velocity
        RequireSingletonForUpdate<GameSettingsComponent>();
        

    }

    protected override void OnUpdate()
    {
        var gameSettings = GetSingleton<GameSettingsComponent>();
        float deltaTime = Time.DeltaTime;
        


        Entities.WithAll<AsteroidTag>()
            .ForEach((Entity entity, ref Rotation rotation) => {
                
                rotation.Value = math.mul(rotation.Value, quaternion.RotateY(gameSettings.asteroidRotation * deltaTime));

        }).Schedule();
    }
}
