using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Wood,
        Stone,
        Seeds,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite ()
    {
        switch (itemType)
        {
            default:
            case ItemType.Stone: return ItemAssets.Instance.stoneSprite;
            case ItemType.Wood: return ItemAssets.Instance.woodSprite;
            case ItemType.Seeds: return ItemAssets.Instance.seedsSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Stone:
            case ItemType.Wood:
            case ItemType.Seeds:
                return true;
        }
    }
}
