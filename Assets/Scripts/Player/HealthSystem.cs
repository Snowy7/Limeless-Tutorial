using System;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
        public static HealthSystem Instance { get; private set; }

        /// <summary>
        /// Entity's Max Health amount
        /// </summary>
        [SerializeField] private float MaxHealth;
        
        
        
        
        /// <summary>
        /// Entity's current health amount
        /// </summary>
        private float m_health;

        
        private void Awake() 
        { 
                // If there is an instance, and it's not me, delete myself.
                if (Instance != null && Instance != this) 
                { 
                        Destroy(this); 
                } 
                else 
                { 
                        Instance = this; 
                } 
        }

        private void Start()
        {
                m_health = 10f;
        }

        /// <summary>
        /// heal entity , increase health amount
        /// </summary>
        /// <param name="health"></param>
        public void AddHealth(float health)
        {
                m_health += health;
                if(m_health > MaxHealth)
                        m_health = MaxHealth;
                
        }
        /// <summary>
        /// add damage to the entity , reduce the health amount
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
                m_health -= damage;
                if (m_health <= 0)
                        // TODO perform die
                        return;
        }
        
        /// <summary>
        /// function to get the current entity's health
        /// </summary>
        /// <returns>float current health</returns>
        public float GetHealth()
        {
                return m_health;
        }
}
