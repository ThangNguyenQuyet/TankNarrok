using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventDamage : UnityEvent<float,float>
{ 

}

public class TankHealthData : MonoBehaviour
{
    [SerializeField]
    private float m_MaxHealth;
    [SerializeField]
    private float m_CurrentHealth;
    public EventDamage m_CallTakeDamage;
    public UnityEvent Death;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        m_CallTakeDamage?.Invoke(m_MaxHealth, Mathf.Max(m_CurrentHealth, 0));
    }

    public void TakeDamage(float Damage)
    {
        m_CurrentHealth -= Damage;
        m_CallTakeDamage?.Invoke(m_MaxHealth,Mathf.Max(m_CurrentHealth,0));
        if (m_CurrentHealth<=0)
        {
            m_CurrentHealth = 0;
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Death?.Invoke();
        Destroy(gameObject);
    }
}
