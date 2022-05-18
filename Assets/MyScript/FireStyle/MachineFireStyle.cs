using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFireStyle : FireStyleComp
{
    public float currentInterval = 0.0f;

    public override void OnGunFireTrigger()
    {
        base.OnGunFireTrigger();
    }
    public override void OnDoneTrigger()
    {
        base.OnDoneTrigger();

    }

}
