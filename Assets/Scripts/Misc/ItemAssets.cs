using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Header("Tools Sprites")]
    public Sprite pickaxeSprite;
    public Sprite axeSprite;
    public Sprite hoeSprite;

    [Header("Resources Sprites")]
    public Sprite stoneSprite;
    public Sprite woodSprite;
    public Sprite seedsSprite;

}
