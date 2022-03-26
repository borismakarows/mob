using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
 
    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.gameObject.SetActive(currentHealth > 0);
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
        slider.minValue = 0;
    }
}
