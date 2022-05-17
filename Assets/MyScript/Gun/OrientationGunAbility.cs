using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationGunAbility : GunAbilty
{
    [SerializeField]
    private float m_RangeDirect = 0;

    public override void DoUpdate(FireStyleComp fireStyleComp)
    {
        base.DoUpdate(fireStyleComp);
        var firestyleComp = fireStyleComp as OrientationFireStyle;

    }
}
