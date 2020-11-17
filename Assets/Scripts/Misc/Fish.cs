using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public float catchTimer = 0;

    private void OnTriggerStay2D(Collider2D collision)
{
        //Debug.Log(catchTimer);
        if (collision.gameObject.tag == "Fish") catchTimer++;
    }
}
