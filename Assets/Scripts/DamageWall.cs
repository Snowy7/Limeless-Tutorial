
using System;
using UnityEngine;

public class DamageWall : MonoBehaviour , IDamagable
{
    public float m_health;
    public float m_damage;
    [SerializeField]
    public float damageAmount { get; set; }
    
    [SerializeField] public bool isDestructible { get; private set; }
    

    private void OnTriggerStay(Collider other)
    {
        print("OnCollisionStay");
        if (other.gameObject.CompareTag("Player"))
        {
            print(other.gameObject.name);
            HealthSystem.Instance.TakeDamage(m_damage);
        }    }
}
