using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    #region SERIALIZED PRIVATE VAR
    [Header("Day and Night Gradients")]
    [SerializeField] Gradient dayGradientPallete;
    [SerializeField] Gradient clockIdicatorPallete;

    [Header("Global Light")]
    [SerializeField] Light2D mainLighting;

    [Header("Sprites For Changing Day Indicator SpriteRenderer")]
    [SerializeField] Image dayIndicatorImage;
    [SerializeField] Sprite dayIndicatorMoonImage;
    [SerializeField] Sprite dayIndicatorSunImage;

    [Header("Time of Day")]
    [SerializeField, Range(0, 1)] private float timeofDay;
    [SerializeField] float timeoffset = 0.05f;

//   [Header("DEBUG parameters")]
//    [SerializeField] Slider dayTimeDebugSlider;

    [Header("Respawn Player")]
    [SerializeField] GameObject spawnPlayerPosition;
    [SerializeField] GameObject player;
    [SerializeField] Animator newDayTransitionAnimator;
    #endregion
    #region PRIVATE VAR
    int dayCount;
    bool lightsOff = true;
    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        GameEventSystem.current.OnResetTime += EndDay;
    }

    private void OnDisable()
    {
        GameEventSystem.current.OnResetTime -= EndDay;
    }

    private void Update()
    {
        UpdateTime();
        UpdateLighting();
        SwitchClockImage();
    }
    #endregion
    #region CONTROLLER METHODS
    void UpdateTime()
    {
        timeofDay += Time.deltaTime * timeoffset;
    }

    void UpdateLighting()
    {
        dayIndicatorImage.color = clockIdicatorPallete.Evaluate(timeofDay);
        mainLighting.color = dayGradientPallete.Evaluate(timeofDay);
    }

    void SwitchClockImage()
    {
        if (timeofDay > 0.7f && lightsOff)
        {
            dayIndicatorImage.sprite = dayIndicatorMoonImage;
            GameEventSystem.current.Time(); // Call event to enable Fireflies
            lightsOff = false;
        }

        else if (timeofDay < 0.7f) dayIndicatorImage.sprite = dayIndicatorSunImage;

    }

    public void EndDay()
    {
        StartCoroutine(NextDay());
    }

    IEnumerator NextDay()
    {
        newDayTransitionAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        player.transform.position = spawnPlayerPosition.transform.position;
        timeofDay = 0f;
        dayCount++;
        newDayTransitionAnimator.SetTrigger("FadeIn");
        lightsOff = true;
    }
    #endregion
}
