using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    [SerializeField]
    private float m_MaxLifeTime;
    [SerializeField]
    private ParticleSystem m_ExplosionAnimation;
    [SerializeField]
    private float m_Damage=3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell")) return;
        Debug.Log("trigger Exp: " + other.tag);
        if (other.tag == "Player")
        {
            TankHealthData TankHealth = other.GetComponentInParent<TankHealthData>();
            TankHealth.TakeDamage(m_Damage);
        };
        m_ExplosionAnimation.transform.parent = null;
        m_ExplosionAnimation.Play();
        ParticleSystem.MainModule mainModule = m_ExplosionAnimation.main;
        Destroy(m_ExplosionAnimation.gameObject, mainModule.duration);
        Destroy(gameObject);
    }
}
