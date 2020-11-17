using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    [Header("Energy Slider Values")]
    SliderBarScript slider;
    [SerializeField] int maxSliderValue;

    private void Start()
    {
        slider = GetComponent<SliderBarScript>();
        slider.SetMaxValue(maxSliderValue);
        GameEventSystem.current.OnHitEvent += DecreseEnergyByFive;
        GameEventSystem.current.OnFishingEventEnd += IncreaseEnergyByTen;
    }
    private void DecreseEnergyByFive()
    {
        slider.DecreaseSliderValue(5);
    }
    private void IncreaseEnergyByTen()
    {
        slider.AddSliderValue(10);
    }

    private void OnDisable()
    {
        GameEventSystem.current.OnHitEvent -= DecreseEnergyByFive;
        GameEventSystem.current.OnFishingEventEnd -= IncreaseEnergyByTen;
    }

}
