using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void UpdateHealthBar(float currentValue,float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
