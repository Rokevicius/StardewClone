using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantProgress : HitObject
{
    public List<Sprite> Sprites = new List<Sprite>();

    public int daysToGrow;

    public int dropCount;
    public float dropRadius;

    public GameObject dropablePlantPrefab;
}
