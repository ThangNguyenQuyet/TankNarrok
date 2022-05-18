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
    public FireStyleComp defaultFireStyle;
    private FireStyleComp currentFireStyle;
    public int m_CountBullet = 0;
    public int m_GunType = 0;

    void Start()
    {
        currentFireStyle = defaultFireStyle;
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
        if (Input.GetMouseButton(0) && currentFireStyle.IsReady) Fire();
    }

    public void Fire()
    {
        currentFireStyle.OnGunFireTrigger();
        Debug.Log("fire: " + currentFireStyle.bulletFired.ToString() + " " + currentFireStyle.gunAbility.m_NumBullet);
        if (currentFireStyle.bulletFired == currentFireStyle.gunAbility.m_NumBullet)
        {
            currentFireStyle.bulletFired = 0;
            currentFireStyle.gunAbility = defaultFireStyle.gunAbility;
        }
    }

}
