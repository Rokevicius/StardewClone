using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTool : MonoBehaviour
{
    public static CurrentTool Instance { get; private set; }
    GameObject prevArrow;
    TypeTool toolType;

    private void Awake()
    {
        Instance = this;
    }


    public enum TypeTool
    {
        Axe,
        PickAxe,
        Hoe,
    }

    public void SetToolType(TypeTool toolType)
    {
        this.toolType = toolType;

        switch (toolType)
        {
            case TypeTool.Axe:
                break;
            case TypeTool.PickAxe:
                break;
            case TypeTool.Hoe:
                break;
        }
    }

    public TypeTool getTypeTool()
    {
        return toolType;
    }

    public void SetAxe(GameObject arrowImage)
    {
        SetToolType(TypeTool.Axe);
        SetArrow(arrowImage);
    }

    public void SetHoe(GameObject arrowImage)
    {
        SetToolType(TypeTool.Hoe);
        SetArrow(arrowImage);
    }

    public void SetPickAxe(GameObject arrowImage)
    {
        SetToolType(TypeTool.PickAxe);
        SetArrow(arrowImage);
    }

    public void SetTool(TypeTool tool, GameObject arrowImage)
    {
        SetToolType(tool);
    }

    void SetArrow(GameObject arrow)
    {
        if(prevArrow != null) prevArrow.SetActive(false);
        arrow.SetActive(true);
        prevArrow = arrow;
    }
}
