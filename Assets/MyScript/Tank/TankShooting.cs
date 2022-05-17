using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankShooting : MonoBehaviour
{
    public Transform m_ShootTransform;
    [SerializeField]
    private float m_Force;
    [SerializeField]
    private float m_MaxTimeLife;
    private bool IsFired = false;
    public FireStyleComp[] m_GunObject;
    public int m_CountBullet=0;
    public UnityEvent eventt;
    public int m_GunType = 0;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < m_GunObject.Length; ++i)
        //{
        //    m_GunObject[i].FireTranPos = m_ShootTransform;
        //    m_GunObject[i].IsReady = true;
        //}

    }

    // Update is called once per frame
    public void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (!IsFired)
        //    {
        //        IsFired = true;
        //        Fire();
        //    }
        //} else if (Input.GetMouseButtonUp(0)) IsFired = false;
        if (Input.GetMouseButton(0) && (m_CountBullet > 0 || m_GunType == 0) && !IsFired) Fire();
        if (m_GunObject[m_GunType].IsReady) IsFired = false;
    }

    public void Fire()
    {
        IsFired = true;
        Debug.Log("Gun type: "+m_GunObject.GetType().Name);
        //Debug.Log("Fire "+ m_GunObject[m_GunType].IsReady.ToString());
        //m_GunObject[m_GunType].OnGunFireTrigger();
        m_GunObject[m_GunType].OnGunFireTrigger();
        //Debug.Log(m_GunObject[m_GunType].IsReady.ToString());
        //GameObject s = Instantiate(m_Shoot, m_ShootTransform.position, m_ShootTransform.rotation);
        //Rigidbody rigid = s.GetComponent<Rigidbody>();
        //rigid.velocity = m_ShootTransform.forward * 20;
        if (m_GunType != 0)
        {
            --m_CountBullet;
                if (m_CountBullet == 0) m_GunType = 0;
        }
        eventt?.Invoke();
    }
    public void DoneFired()
    {
        IsFired = false;
    }
}
