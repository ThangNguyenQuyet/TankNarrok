using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAbilty : ScriptableObject
{
    public int m_NumBullet;
    public Rigidbody m_ShellType;
    public float bulletStartSpeed;

    public virtual void DoUpdate(FireStyleComp fireStyleComp)
    {
        //isFired = false;
    }

    protected virtual void FireOneBullet1(Transform transform)
    {
        Debug.Log("fire1");
        var bullet = Instantiate(m_ShellType, transform.position, transform.rotation);
        if (bullet.TryGetComponent<Rigidbody>(out var rigid))
        {
            rigid.velocity = transform.forward * bulletStartSpeed;
        }
    }
}
