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
    private float currentReloadTime = 0;
    internal int bulletFired = 0;
    internal bool IsReady = true;
    public Transform FireTranPos;
    public int m_GunType=0;
    public UnityEvent DoneFired;

    public void Start()
    {
        //for (int i = 0; i < gunAbility.Length; ++i)
        //    gunAbility[i] ;
    }

    public void InitWeapon(Transform FireTranPos)
    {
        this.FireTranPos = FireTranPos;
    }

    public void Update()
    {
        //Debug.Log(IsReady);
        if (!IsReady)
        {
            Debug.Log("1");
            if (this == null) Debug.Log("this null"); else Debug.Log("This not null");
            gunAbility.DoUpdate(this);
        }
    }

    public void OnGunFireTrigger()
    {
        Debug.Log("33: "+IsReady);
        if (!IsReady && currentReloadTime > 0)
        {
            Debug.Log("333");
            return;
        }    
        Debug.Log('3');
        IsReady = false;
        currentReloadTime = reloadTime;
        bulletFired = 0;
    }


    public virtual void OnDoneTrigger()
    {
        
        DoneFired?.Invoke();
        IsReady = true;
    }
}
