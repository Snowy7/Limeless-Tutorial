using System;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    /// Generic factory for creating abilities dynamically.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // <T> where T : IAbility means that T must be a type that implements the IAbility interface.
    public class AbilityFactory<T> where T : IAbility
    {
        private readonly Dictionary<string, Type> abilityTypes;
        private readonly GameObject abilityContainer;

        /// <summary>
        /// Initializes the factory with a container for the abilities.
        /// </summary>
        /// <param name="abilityContainer">Parent GameObject for ability components.</param>
        public AbilityFactory(GameObject abilityContainer)
        {
            abilityTypes = new Dictionary<string, Type>();
            this.abilityContainer = abilityContainer;
        }

        /// <summary>
        /// Registers an ability type with a unique key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RegisterAbility(string key, Type type)
        {
            // Check if the type is valid
            if (!typeof(T).IsAssignableFrom(type))
            {
                // the ability type must implement the IAbility interface
                throw new ArgumentException($"Type {type.Name} must implement {typeof(T).Name}.");
            }
            
            abilityTypes.Add(key, type);
        }

        /// <summary>
        /// Creates an ability instance of the specified type.
        /// </summary>
        /// <param name="key">Ability Identifier</param>
        /// <param name="name">Ability name</param>
        /// <param name="cooldownDuration">Cooldown Duration</param>
        /// <param name="value">Damage or heal amount.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public T CreateAbility(string key, string name, float cooldownDuration, float value, bool isHeal = false)
        {
            if (!abilityTypes.TryGetValue(key, out var type))
            {
                throw new ArgumentException($"Ability with key {key} is not registered.");
            }
            
            var ability = abilityContainer.AddComponent(type) as IAbility;
            ability?.Initialize(name, cooldownDuration, value, isHeal);
            return (T)ability;
        }
    }
}