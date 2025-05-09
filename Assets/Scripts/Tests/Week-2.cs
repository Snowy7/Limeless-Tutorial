using Abilities;
using UnityEngine;

namespace Tests
{
    // Generics: allow you to write flexible & type-safe code. it will work with any data type defined using a placeholder like <T>
    /*public class AbilityFactory<T> where T : IAbility
    {
        public T CreateAbility(string key)
        {
            /* Create a new Ability #1#
            return ..;
        }
    }*/
    
    // Usage: AbilityFactory<Fireball> abilityFactory = new AbilityFactory<Fireball>();
    // var fireballAbility = abilityFactory.CreateAbility("Fireball");
    // This will create a new instance of the Fireball ability using the factory.
    
    // Delegates: a type that represents references to methods with a specific parameter list and return type.
    // They are used to define callback methods, event handlers, and can be passed as parameters to other methods.
    // You can invoke it from a different class or method.
    // not linked to a specific class or object.
    // Delegates are similar to function pointers in C/C++ but are type-safe and object-oriented.
    // Purpose: allow dynamic method calls for custom actions
    
    /*public delegate void AbilityAction(int abilityId);
    
    public class Test
    {
        public static Test instance;
        
        public AbilityAction OnAbilityActivated;
        public AbilityAction OnAbilityDeactivated;
        
        void Start()
        {
            // Subscribe to the delegate
            OnAbilityActivated += HandleAbilityActivated;
            OnAbilityDeactivated += HandleAbilityDeactivated;

            instance = this;
        }
        
        void HandleAbilityActivated(int abilityId)
        {
            // Handle the ability activation
            Debug.Log($"Ability {abilityId} activated!");
        }
        
        void HandleAbilityDeactivated(int abilityId)
        {
            // Handle the ability deactivation
            Debug.Log($"Ability {abilityId} deactivated!");
        }
        
        public void ActivateAbility()
        {
            // Invoke the delegate
            OnAbilityActivated?.Invoke(0);
        }
        
        public void DeactivateAbility()
        {
            // Invoke the delegate
            OnAbilityDeactivated?.Invoke(0);
        }
    }

    class Test2
    {
        void Start()
        {
            Test.instance.OnAbilityActivated += HandleAbilityActivated;
            
            Test.instance.OnAbilityActivated?.Invoke(1);
        }
        
        void HandleAbilityActivated(int abilityId)
        {
            // Handle the ability activation
            Debug.Log($"Ability {abilityId} activated!");
        }
    }*/    
    
    // Events: a special kind of delegate that can be used to notify subscribers when something happens.
    // They are used to implement the observer pattern, allowing multiple subscribers to listen for and respond to events.
    // Events are based on delegates but provide additional features like encapsulation and thread safety.
    
    // Purpose: allow multiple subscribers to listen for and respond to events
    
    // Usage:
    /*public class Test
    {
        public static Test instance;
        
        public event System.Action OnAbilityActivated;
        public static event System.Action OnAbilityDeactivated;
        
        void Start()
        {
            // Subscribe to the event
            OnAbilityActivated += HandleAbilityActivated;
            OnAbilityDeactivated += HandleAbilityDeactivated;
        }
        
        void HandleAbilityActivated()
        {
            // Handle the ability activation
            Debug.Log("Ability activated!");
        }
        
        void HandleAbilityDeactivated()
        {
            // Handle the ability deactivation
            Debug.Log("Ability deactivated!");
        }
        
        public void ActivateAbility()
        {
            // Invoke the event
            OnAbilityActivated?.Invoke();
        }
        
        public void DeactivateAbility()
        {
            // Invoke the event
            OnAbilityDeactivated?.Invoke();
        }
    }
    
    class Test2
    {
        void Start()
        {
            Test.instance.OnAbilityActivated += HandleAbilityActivated;
            
            Test.OnAbilityDeactivated?.Invoke();
        }
        
        void HandleAbilityActivated()
        {
            // Handle the ability activation
            Debug.Log("Ability activated!");
        }
    }*/
}