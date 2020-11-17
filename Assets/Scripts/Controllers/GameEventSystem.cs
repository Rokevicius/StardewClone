using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnHitEvent;
    public void HitEvent()
    {
        OnHitEvent?.Invoke();
    }

    public event Action OnTime;
    public void Time()
    {
        OnTime?.Invoke();
    }

    public event Action OnResetTime;
    public void ResetTime()
    {
        OnResetTime?.Invoke();
    }

    public event Action OnFishingEvent;
    public void FishingEvent()
    {
        OnFishingEvent?.Invoke();
    }

    public event Action OnFishingEventEnd;
    public void FishingEventEnd()
    {
        OnFishingEventEnd?.Invoke();
    }

    public event Action OnButtonClick;
    public void ButtonClick()
    {
        OnButtonClick?.Invoke();
    }

    public event Action OnHarvestComplete;
    public void HarvestComplete()
    {
        OnHarvestComplete?.Invoke();
    }
}
