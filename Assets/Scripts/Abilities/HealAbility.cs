using System;
using Abilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Abilities
{
    public class HealAbility : BaseAbility
    {
        [SerializeField] private float healAmount;
        [SerializeField] float cooldown;
        
        private void Start()
        {
            Initialize("HealAbility",cooldown,healAmount);
        }

        protected override void PerformAbility()
        {
            HealthSystem.Instance.AddHealth(healAmount);
        }
    }

}
