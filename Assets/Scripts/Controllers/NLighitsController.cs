using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLighitsController : MonoBehaviour
{
    [SerializeField] GameObject nLights;

    void EnableLights()
    {
        Debug.Log("N CAAAAAAAAAAL");
        nLights.SetActive(true);
    }

    void DisableLights()
    {
        nLights.SetActive(false);
    }

    private void OnDisable()
    {
        GameEventSystem.current.OnTime -= EnableLights;
        GameEventSystem.current.OnResetTime -= DisableLights;
    }

    private void Start()
    {
       // Debug.Log(GameEventSystem.current);
        GameEventSystem.current.OnTime += EnableLights;
        GameEventSystem.current.OnResetTime += DisableLights;
    }
}
