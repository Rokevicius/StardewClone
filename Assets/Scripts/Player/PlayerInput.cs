using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{

    [SerializeField] Joystick js;

    public float Horizontal { get; private set; }

    public float Vertical { get; private set; }

#if UNITY_IOS || UNITY_ANDROID
    void Update()
    {
        Horizontal = js.Horizontal;
        Vertical = js.Vertical;
    }
#else
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
#endif
}