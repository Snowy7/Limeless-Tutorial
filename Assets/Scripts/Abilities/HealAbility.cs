using System;
using UnityEngine;

namespace Abilities
{
    public class HealAbility : BaseAbility
    {
        // Heal amount replaces Damage for this ability
        private float HealAmount { get; set; }
        
        public override void Initialize(string abilityName, float cooldownDuration, float healAmount, bool isHeal = true)
        {
            if (!isHeal)
            {
                throw new ArgumentException("HealAbility can only be initialized with isHeal set to true.");
            }
            
            base.Initialize(abilityName, cooldownDuration, healAmount);
            HealAmount = healAmount;
        }

        protected override void PerformAbility()
        {
            Debug.Log($"{Name} activated, restoring {HealAmount} health!");
        }
    }
}