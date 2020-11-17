using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingController : MonoBehaviour
{
    [SerializeField] UIManager uiManger;
    [SerializeField] Fishing fishing;
    [SerializeField] Sprite fishImage;
    [SerializeField] Image useButtonImage;
    Sprite oldButtonSprite;

    bool inFishingArea = false;

    private void Start()

    {
        GameEventSystem.current.OnButtonClick += StartFishing;
        oldButtonSprite = useButtonImage.sprite;
    }

    private void OnDisable()
    {
        GameEventSystem.current.OnButtonClick -= StartFishing;
    }

    private void OnTriggerStay2D(Collider2D collision)
{
        if (collision.gameObject.tag == "Player")
        {
            useButtonImage.sprite = fishImage;
            inFishingArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        useButtonImage.sprite = oldButtonSprite;
        inFishingArea = false;
    }

    void StartFishing()
    {
        if(inFishingArea)
        {
            Debug.Log("Started Fishing");
            uiManger.OpenCloseFishing();
            fishing.enabledF = true;
        }
    }
}
