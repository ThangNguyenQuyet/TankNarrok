using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ShotGunAbility")]
public class ShotgunAbility : GunAbilty
{
    public float m_Range = 120;
    public override void DoUpdate(FireStyleComp fireStyleComp)
    {
        base.DoUpdate(fireStyleComp);
        var firestyleComp = fireStyleComp as ShotgunFireStyle;
        float RangeBullet = m_Range / m_NumBullet;
        for (int i = 0; i < m_NumBullet; ++i)
        {
            Transform tmp = Instantiate(firestyleComp.FireTranPos);
            tmp.position = fireStyleComp.FireTranPos.position;
            tmp.rotation = fireStyleComp.FireTranPos.rotation;
            tmp.Rotate((new Vector3(0, -m_Range / 2 + i * RangeBullet, 0)));
            FireOneBullet1(tmp);
            firestyleComp.bulletFired++;
            Destroy(tmp.gameObject);
        }

        if (fireStyleComp.bulletFired >= m_NumBullet)
            firestyleComp.OnDoneTrigger();
    }

    protected override void FireOneBullet1(Transform transform)
    {
        base.FireOneBullet1(transform);
    }
}
