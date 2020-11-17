using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : PlantProgress
{
    SpriteRenderer plantSprite;

    int daysSincePlanted = 0;

    private void Start()
    {
        GameEventSystem.current.OnResetTime += GrowPlant;

        plantSprite = gameObject.GetComponentInChildren<SpriteRenderer>();

        dropCount = Random.Range(1, 3);
    }

    void GrowPlant()
    {
        Debug.Log("plant Growing!");
        plantSprite.sprite = Sprites[daysSincePlanted];
        daysSincePlanted++;
    }
    private void Update()
    {
        Debug.Log(daysSincePlanted);
    }

    public override void OnHit()
    {
        if (daysToGrow <= daysSincePlanted)
        {
            if (CurrentTool.Instance.getTypeTool() == CurrentTool.TypeTool.Hoe)
            {
                GameEventSystem.current.HitEvent();

                while (dropCount > 0)
                {
                    Instantiate(dropablePlantPrefab, transform.position, Quaternion.identity);
                    dropCount--;
                }
                Destroy(transform.gameObject);
                GameEventSystem.current.HarvestComplete();
            }
        }
    }
}

