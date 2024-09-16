using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        Health.onHealthChange += UpdateHealthBar;
    }

    private void OnDisable()
    {
        Health.onHealthChange -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        slider.maxValue = health.GetMaxHealth();
        slider.value = health.GetHealth();
    }
}
