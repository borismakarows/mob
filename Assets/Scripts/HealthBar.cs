using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    Health myHealth;

    void Awake()
    {
        myHealth = GetComponent<Health>();    
    }

    void Start()
    {
        slider.maxValue = myHealth.GetMaxHealth();
        
    }

    void Update()
    {
        slider.value = myHealth.GetCurrentHealth();
    }


}
