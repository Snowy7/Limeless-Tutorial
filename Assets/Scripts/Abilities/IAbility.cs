using System;

namespace Abilities
{
    /// <summary>
    /// Defines the structure for an ability in the game.
    /// </summary>
    public interface IAbility
    {
        /// <summary>
        /// Gets the name of the ability!
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the cooldown duration of the ability.
        /// </summary>
        float CooldownDuration { get; }
        
        /// <summary>
        /// Gets the damage of the ability.
        /// </summary>
        float Damage { get; }

        /// <summary>
        /// Event triggered when the ability is activated!
        /// </summary>
        event Action OnAbilityActivated;

        /// <summary>
        /// Initializes the ability with the specified parameters.
        /// </summary>
        /// <param name="abilityName"></param>
        /// <param name="cooldownDuration"></param>
        /// <param name="damage"></param>
        void Initialize(string abilityName, float cooldownDuration, float damage, bool isHeal = false);
        
        /// <summary>
        /// Attempts to activate the ability.
        /// </summary>
        void Activate();
    }
}