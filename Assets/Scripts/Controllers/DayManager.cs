using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    int day = 0;

    private void Start()
    {
        GameEventSystem.current.OnResetTime += EndDay;
    }

    void EndDay()
    {
        day++;

    }

    private void OnDisable()
    {
        GameEventSystem.current.OnResetTime -= EndDay;
    }
}
