using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAbilty : ScriptableObject
{
    public int m_NumBullet = 3;
    public Rigidbody m_ShellType;
    public float bulletStartSpeed = 3;

    public virtual void DoUpdate(FireStyleComp fireStyleComp)
    {
        // Non
    }

    protected virtual void FireOneBullet1(Transform transform)
    {
        Debug.Log("fire1");
        //m_ShellType.Init(transform,force);
        var bullet = Instantiate(m_ShellType, transform.position, transform.rotation);
        if (bullet.TryGetComponent<Rigidbody>(out var rigid))
        {
            rigid.velocity = transform.forward * bulletStartSpeed;
            //rigid.AddForce(fireDir*force);
        }
    }

}
