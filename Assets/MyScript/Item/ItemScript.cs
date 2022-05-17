using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemScript;

public class ItemScript : MonoBehaviour, ICollecableItem
{
    [SerializeField]
    private GameObject m_GunType;

    [SerializeField]
    private int m_CountBullet;

    [SerializeField]
    private float m_ReloadTime;

    internal Action OnCollectedItem;

    private void Update()
    {
        GetComponent<Transform>().Rotate(1, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other != null && other.CompareTag("Player"))
        {
            Transform will_be_destroy=other.GetComponent<Transform>().Find("Machinegun(Clone)");
            if (will_be_destroy!=null) Destroy(will_be_destroy.gameObject);
            //other.GetComponentInParent<3>().m_GunType = m_GunType;
            GameObject tmp = Instantiate(m_GunType, other.GetComponentInParent<Transform>());

            tmp.GetComponent<FireStyleComp>().reloadTime = m_ReloadTime;
            other.GetComponentInParent<TankShooting>().m_GunObject[1] = tmp.GetComponent<FireStyleComp>();
            other.GetComponentInParent<TankShooting>().m_CountBullet = m_CountBullet;
            tmp.GetComponent<FireStyleComp>().FireTranPos = other.GetComponentInParent<TankShooting>().m_ShootTransform;
            Debug.LogError(OnCollectedItem == null);
            OnCollectedItem?.Invoke();
            Destroy(gameObject);
        };
    }

    public void AsignOnCollectAction(Action action)
    {
        OnCollectedItem += action;
    }
}

public interface ICollecableItem
{
    public void AsignOnCollectAction(Action action);
}
