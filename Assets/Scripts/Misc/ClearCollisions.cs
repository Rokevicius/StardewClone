using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCollisions : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collided!", collision.gameObject);
        if (collision.gameObject.tag == "Grass")
        {
            Destroy(collision.gameObject);
        }
    }
}
