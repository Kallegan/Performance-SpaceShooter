using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.Physics;

public partial class InputMovementSystem : SystemBase
{
    protected override void OnCreate()
    {
        //We will use playerForce from the GameSettingsComponent to adjust velocity
        RequireSingletonForUpdate<GameSettingsComponent>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    protected override void OnUpdate()
    {
        //we must declare our local variables to be able to use them in the .ForEach() below
        var gameSettings = GetSingleton<GameSettingsComponent>();
        var deltaTime = Time.DeltaTime;

        //we will control thrust with WASD"
        byte right, left, thrust, reverseThrust;
        right = left = thrust = reverseThrust = 0;

        //we will use the mouse to change rotation
        float mouseX = 0;
        float mouseY = 0;

        //we grab "WASD" for thrusting
        if (Input.GetKey(KeyCode.D))
        {
            right = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            thrust = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            reverseThrust = 1;
        }                
        
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");        

        Entities
        .WithAll<PlayerTag>()
        .ForEach((Entity entity, ref Rotation rotation, ref PhysicsVelocity velocity) =>
        {
            if (right == 1)
            {   //thrust to the right of where the player is facing
                velocity.Linear += (math.mul(rotation.Value, new float3(1, 0, 0)).xyz) * gameSettings.playerForce * deltaTime;
            }
            if (left == 1)
            {   //thrust to the left of where the player is facing
                velocity.Linear += (math.mul(rotation.Value, new float3(-1, 0, 0)).xyz) * gameSettings.playerForce * deltaTime;
            }
            if (thrust == 1)
            {   //thrust forward of where the player is facing
                velocity.Linear += (math.mul(rotation.Value, new float3(0, 0, 1)).xyz) * gameSettings.playerForce * deltaTime;
            }
            if (reverseThrust == 1)
            {   //thrust backwards of where the player is facing
                velocity.Linear += (math.mul(rotation.Value, new float3(0, 0, -1)).xyz) * gameSettings.playerForce * deltaTime;
            }
            if (mouseX != 0 || mouseY != 0)
            {   //move the mouse                
                float lookSpeedX = gameSettings.cameraSensetivityX;
                float lookSpeedY = gameSettings.cameraSensetivityY;

                //Poorly and unclear camera, update if time allows. Had to create custom clamp since it went from 0 to 90 when looking down and 360 to 270 when looking up.               
                Quaternion currentQuaternion = rotation.Value;
                float yaw = currentQuaternion.eulerAngles.y;
                float pitch = currentQuaternion.eulerAngles.x;    
                
                yaw += lookSpeedX * mouseX;
                pitch -= lookSpeedY * mouseY;

                if (pitch < 270 && pitch >= 89)
                    pitch = 89;
                else if (pitch > 270 && pitch <= 281)
                    pitch = 281;

                Quaternion newQuaternion = Quaternion.identity;
                newQuaternion.eulerAngles = new Vector3(pitch, yaw, 0);
                rotation.Value = newQuaternion;             
                
            }
        }).ScheduleParallel();
    }
}