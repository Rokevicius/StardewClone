using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : HitObject
{
    public override void OnHit()
    {
        Destroy(gameObject);
    }
}
