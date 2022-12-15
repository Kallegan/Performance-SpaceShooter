using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputManager : MonoBehaviour
{
   public enum InputType
   {
        PlayerDesktop,
        PlayerMobile,
        AI
   }

    public static IMovementControls GetMovementControls(InputType inputType)
    {
        return inputType switch
        {
            InputType.PlayerDesktop => new MKBMovementControls(),
            InputType.PlayerMobile => null,
            InputType.AI => null,
            _ => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null)
        };
    }

    public static IWeaponControls GetWeaponControls(InputType inputType)
    {
        return inputType switch
        {
            InputType.PlayerDesktop => new MKBWeaponControls(),
            InputType.PlayerMobile => null,
            InputType.AI => null,
            _ => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null)
        };
    }
}
