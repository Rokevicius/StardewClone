using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    int spwawnCount;
    [SerializeReference] GameObject grass;
    [SerializeReference] float radius;
    [SerializeReference] int minRange;
    [SerializeReference] int maxRange;

    private void Start()
    {
        spwawnCount = Random.Range(minRange, maxRange);
    }
    private void Update()
    {
        while (spwawnCount > 0)
        {
            
            Instantiate(grass, Random.insideUnitSphere * radius + transform.position, Quaternion.identity);
            spwawnCount--;
        }
    }
}
