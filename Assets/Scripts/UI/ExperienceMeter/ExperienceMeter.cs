using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceMeter : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        ExperienceManager.onExperienceChanged += UpdateSlider;
    }
    
    private void OnDisable()
    {
        ExperienceManager.onExperienceChanged -= UpdateSlider;
    }

    private void UpdateSlider()
    {
        slider.maxValue = ExperienceManager.instance.GetExperiencePerLevel();
        slider.value = ExperienceManager.instance.GetExperience();
    }
}
