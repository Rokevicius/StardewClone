using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseButton : MonoBehaviour
{
    [SerializeField] ToolsController toolsController;
    Sprite buttonSprite;

#if UNITY_IOS || UNITY_ANDROID
    private void Awake()
    {
        transform.gameObject.SetActive(true);
    }

#else
    private void Awake()
    {
        this.gameObject.GetComponent<Image>().enabled = false ;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
#endif

#if UNITY_STANDALONE
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameEventSystem.current.ButtonClick();
        }
    }
#endif
    public void ButtonUse()
    {
        Debug.Log("Called");
        GameEventSystem.current.ButtonClick();
    }
}
