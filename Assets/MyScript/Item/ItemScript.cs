using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemScript;

public class ItemScript : MonoBehaviour, ICollecableItem
{
    [SerializeField]
    private GunAbilty m_GunType;


    [SerializeField]
    private int m_CountBullet;

    [SerializeField]
    private float m_ReloadTime;

    [SerializeField]
    private float m_Degree;


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
            other.GetComponentInParent<TankShooting>().currentFireStyle.gunAbility = m_GunType;
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
