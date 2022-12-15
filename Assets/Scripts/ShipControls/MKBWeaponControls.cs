using System;
using UnityEngine;

[Serializable]
public class MKBWeaponControls : WeaponControlsBase
{
    public override bool PrimaryFired => Input.GetMouseButton(0);
    public override bool SecondaryFired => Input.GetMouseButton(1);
}