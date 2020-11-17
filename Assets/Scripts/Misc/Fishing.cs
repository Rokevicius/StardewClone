using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [SerializeField] BoxCollider2D greenCollider;
    [SerializeField] CircleCollider2D fishCollider;

    [SerializeField] UIManager uiManger;
    [SerializeField] Slider fishSlider;
    [SerializeField] float offset = 50;
    Slider slider;
    [SerializeField] float speedDecrease = 1f;
    [SerializeField] float sliderInc = 5f;
    int click;
    float oldOffset;
    public bool enabledF = false;
    Fish fish;

    void Start()
    {
        oldOffset = offset;
        slider = GetComponent<Slider>();
        fish = fishCollider.gameObject.GetComponent<Fish>();
        slider.maxValue = 50;
        slider.value = slider.maxValue / 2;

        fishSlider.maxValue = 25;
        fishSlider.value = fishSlider.minValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (enabledF)
        {
            Debug.Log("Enabled Fishing Event");
            slider.value -= speedDecrease * Time.deltaTime;

            fishSlider.value += offset * Time.deltaTime;

            if (Input.GetButtonDown("Fire1"))
            {
                click++;
                slider.value += sliderInc;
            }
            if (click == 5)
            {
                StartCoroutine(EnableTimedBonus());
                click = 0;
            }

            if (fishSlider.value == fishSlider.minValue) offset = offset * -1;

            CheckForWin();
        }
    }

    IEnumerator EnableTimedBonus()
    {
        offset = -1 * offset;
        yield return new WaitForSeconds(5.0f);
        offset = oldOffset;
    }

    void CheckForWin()
    {
        if (fish.catchTimer == 200)
        {
            Win();
        }
    }

    void Win()
    {
        uiManger.OpenCloseFishing();
        fish.catchTimer = 0;
        enabledF = false;
        GameEventSystem.current.FishingEventEnd();
    }
}
