using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    [SerializeField] ToolsController toolsController;

    public void ButtonUse()
    {
        Debug.Log("Called");
        GameEventSystem.current.ButtonClick();
    }
}
