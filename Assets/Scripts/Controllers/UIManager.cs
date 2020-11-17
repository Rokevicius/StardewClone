using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Tween Parameters")]
    public LeanTweenType tweenType;
    public float distanceFromBorder = 10;
    public float transitionTime = 2f;
    public AnimationCurve curve;

    [Header("Settings Page")]
    public RectTransform settingsPage;
    public Button settingsButton;

    [Header("Fishing Page")]
    public RectTransform fishingUI;

    bool sOpen = false;
    bool fOpen = false;

    public void OpenCloseSettings()
    {
        Debug.Log("Called " + sOpen);
        if (!sOpen)
        {
            ToggleUI(settingsPage, new Vector2(settingsPage.anchoredPosition.x, distanceFromBorder));
            sOpen = true;
        }
        else
        {
            ToggleUIBack(settingsPage, new Vector2(settingsPage.anchoredPosition.x, distanceFromBorder));
            sOpen = false;
        }
    }

    public void OpenCloseFishing()
    {
        if (!fOpen)
        {
            ToggleUI(fishingUI, new Vector2(fishingUI.anchoredPosition.x, distanceFromBorder));
            fOpen = true;
        }
        else
        {
            ToggleUIBack(fishingUI, new Vector2(fishingUI.anchoredPosition.x, distanceFromBorder));
            fOpen = false;
        }
    }

    public void ToggleUI(RectTransform target, Vector2 pointGo)
    {
        Vector2 goBackPoint = target.anchoredPosition;
        LeanTween.move(target, pointGo, transitionTime).setEase(curve);
    }

    public void ToggleUIBack(RectTransform target, Vector2 pointGo)
    {
        Vector2 goBackPoint = target.anchoredPosition;
        LeanTween.move(target, new Vector3(0, 1110,0), 0.5f);
    }
}
