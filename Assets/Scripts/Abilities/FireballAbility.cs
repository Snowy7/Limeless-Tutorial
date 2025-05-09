using UnityEngine;

namespace Abilities
{
    /// <summary>
    /// A fireball attack
    /// </summary>
    public class FireballAbility : BaseAbility
    {
        /// <summary>
        /// Performs the fireball ability.
        /// </summary>
        protected override void PerformAbility()
        {
            // For now just logging the effect
            Debug.Log($"{Name} activated, dealing {Damage} damage!");
        }
    }
}