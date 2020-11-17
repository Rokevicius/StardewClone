using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableJoystic : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID
    private void Awake()
    {
        transform.gameObject.SetActive(true);
    }
#else

    private void Awake()
    {
        transform.gameObject.SetActive(false);
    }
#endif
}
