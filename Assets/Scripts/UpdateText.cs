using System;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = HealthSystem.Instance.GetHealth().ToString();
    }
}
