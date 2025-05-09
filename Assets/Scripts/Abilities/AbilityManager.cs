using UnityEngine;

namespace Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        private AbilityFactory<IAbility> m_abilityFactory;

        public delegate void NotifyAction(string message);

        public NotifyAction OnAbilityUsed;

        IAbility m_fireballAbility;
        IAbility m_healAbility;
        
        private void Start()
        {
            // Init Factory
            m_abilityFactory = new AbilityFactory<IAbility>(gameObject);
            m_abilityFactory.RegisterAbility("Throwable", typeof(FireballAbility));
            m_abilityFactory.RegisterAbility("Heal", typeof(HealAbility));
            
            // Create an ability
            m_fireballAbility = m_abilityFactory.CreateAbility("Throwable", "Fireball", 5f, 10f);
            m_healAbility = m_abilityFactory.CreateAbility("Heal", "Heal", 3f, 20f);
            
            // Subscribe to the ability activated event
            OnAbilityUsed = Debug.Log;
            
            m_fireballAbility.OnAbilityActivated += () => OnAbilityUsed?.Invoke($"{m_fireballAbility.Name} activated!");
            m_healAbility.OnAbilityActivated += () => OnAbilityUsed?.Invoke($"{m_healAbility.Name} activated!");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Activate the fireball ability
                m_fireballAbility.Activate();
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                // Activate the heal ability
                m_healAbility.Activate();
            }
        }
    }
}