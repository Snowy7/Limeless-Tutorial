using UnityEngine;

namespace Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private BaseAbility[] abilities;

        private void Update()
        {
            HandleAbility();
        }

        /// <summary>
        /// Handles the activation of abilities based on user input [Alpha keys 0-9].
        /// </summary>
        void HandleAbility()
        {
            // Check for input to activate abilities
            for (int i = 0; i < abilities.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    abilities[i].Activate();
                }
            }
        }
    }
}