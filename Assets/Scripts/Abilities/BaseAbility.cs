using System;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    /// Abstract base class providing common functionality for all abilities.
    /// </summary>
    public abstract class BaseAbility : MonoBehaviour, IAbility
    {
        #region Properties

        /// <summary>
        /// Gets the name of the ability!
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets the cooldown duration of the ability.
        /// </summary>
        public float CooldownDuration { get; private set; }
        
        /// <summary>
        /// Gets the damage of the ability.
        /// </summary>
        public float Damage { get; private set; }
        
        /// <summary>
        /// Event triggered when the ability is activated!
        /// </summary>
        public event Action OnAbilityActivated;
        
        #endregion
        
        #region Private Fields
        
        // Cooldown timer for the ability
        private float m_cooldownTimer;
        
        #endregion

        #region Monobehaviour Methods

        private void Update()
        {
            UpdateCooldown();
        }

        #endregion
        
        /// <summary>
        /// Initializes the ability with the specified parameters.
        /// </summary>
        /// <param name="abilityName"></param>
        /// <param name="cooldownDuration"></param>
        /// <param name="damage"></param>
        /// <exception cref="ArgumentException">If the ability name is null</exception>
        public void Initialize(string abilityName, float cooldownDuration, float damage)
        {
            if (string.IsNullOrEmpty(abilityName))
            {
                throw new ArgumentException("Ability name cannot be null or empty.");
            }
            
            Name = abilityName;
            CooldownDuration = cooldownDuration;
            Damage = damage;
        }

        /// <summary>
        /// Attempts to activate the ability.
        /// </summary>
        public void Activate()
        {
            // Check if the ability is on cooldown
            if (m_cooldownTimer > 0)
            {
                Debug.Log($"{Name} is on cooldown for {m_cooldownTimer:F1} seconds");
                return;
            }

            PerformAbility();
            m_cooldownTimer = CooldownDuration;
            OnAbilityActivated?.Invoke();
        }

        /// <summary>
        /// Updates the cooldown timer.
        /// </summary>
        protected void UpdateCooldown()
        {
            if (m_cooldownTimer > 0)
            {
                m_cooldownTimer -= Time.deltaTime;
            }
        }
        
        /// <summary>
        /// Defines the specific behaviour when the ability is activated!
        /// </summary>
        protected abstract void PerformAbility();
    }
}