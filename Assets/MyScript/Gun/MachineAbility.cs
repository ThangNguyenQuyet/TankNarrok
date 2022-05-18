using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Abilities/MachineAbility")]
public class MachineAbility : GunAbilty
{
    public float m_TimeShell = 0f;
    public float m_degree;
    public UnityEvent OutOfBullet;

    public override void DoUpdate(FireStyleComp fireStyleComp)
    {
        base.DoUpdate(fireStyleComp);

        var firestyleComp = fireStyleComp as MachineFireStyle;
        if (!firestyleComp.Isfired)
        {
            FireOneBullet1(fireStyleComp.FireTranPos);
            firestyleComp.currentReloadTime = m_TimeShell;
            firestyleComp.bulletFired++;
            if (firestyleComp.bulletFired == m_NumBullet) OutOfBullet?.Invoke();
            firestyleComp.Isfired = true;
        }
        else
        {
            if (firestyleComp.currentReloadTime<=0) firestyleComp.OnDoneTrigger();
        }        
    }

    protected override void FireOneBullet1(Transform transform)
    {
        Transform tmp = Instantiate(transform, transform.parent);
        tmp.Rotate(0, UnityEngine.Random.Range(-m_degree, m_degree), 0);
        base.FireOneBullet1(tmp);
        Destroy(tmp.gameObject);
    }

}
