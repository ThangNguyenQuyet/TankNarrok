using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireStyleComp : MonoBehaviour
{
    [SerializeField]
    public GunAbilty gunAbility;
    [SerializeField]
    public float reloadTime = 1;
    public float currentReloadTime = 0;
    internal int bulletFired = 0;
    internal bool IsReady = true;
    public Transform FireTranPos;
    public bool Isfired;

    public void InitWeapon(Transform FireTranPos)
    {
        this.FireTranPos = FireTranPos;
    }

    public void Update()
    {
        //Debug.Log(IsReady);
        if (!IsReady)
        {
            if (currentReloadTime > 0) currentReloadTime -= Time.deltaTime;
            gunAbility.DoUpdate(this);
        }
    }

    public virtual void OnGunFireTrigger()
    {
        if (!IsReady)
        {
            return;
        };
        currentReloadTime = 0;
        Isfired = false;
        IsReady = false;
    }


    public virtual void OnDoneTrigger()
    {
        //DoneFired?.Invoke();
        IsReady = true;
    }
    
}
