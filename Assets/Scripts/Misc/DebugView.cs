using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugView : MonoBehaviour
{
    [SerializeField] BodyMovement direction;

    private void Update()
    {
        transform.position = direction.viewDirection;
    }
}
