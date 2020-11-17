using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepTrigger : MonoBehaviour
{
    bool inArea = false;

    [SerializeField] Sprite sleepSprite;
    [SerializeField] Image useButtonImage;
    Sprite oldButtonSprite;

    private void Start()
    {
        GameEventSystem.current.OnButtonClick += SkipDay;
        oldButtonSprite = useButtonImage.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inArea = true;
        useButtonImage.sprite = sleepSprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inArea = false;
        useButtonImage.sprite = oldButtonSprite;
    }

    void SkipDay()
    {
        if (inArea) GameEventSystem.current.ResetTime();
    }
}
