using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/MachineAbility")]
public class MachineAbility : GunAbilty
{
    public float m_TimeShell = 0f;

    public override void DoUpdate(FireStyleComp fireStyleComp)
    {
        Debug.Log("fire3");
        base.DoUpdate(fireStyleComp);
        var firestyleComp = fireStyleComp as MachineFireStyle;
        firestyleComp.currentInterval -= Time.deltaTime;
        if (firestyleComp.currentInterval <= 0)
        {
            //FireOneBullet(firestyleComp.FireTranPos.position, firestyleComp.FireTranPos.rotation.eulerAngles, firestyleComp.force);

            FireOneBullet1(fireStyleComp.FireTranPos);
            firestyleComp.bulletFired++;
            firestyleComp.currentInterval = m_TimeShell;
        }

        if (fireStyleComp.bulletFired >= m_NumBullet)
            firestyleComp.OnDoneTrigger();
    }

    protected override void FireOneBullet1(Transform transform)
    {
        base.FireOneBullet1(transform);
    }
}
