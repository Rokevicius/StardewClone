using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : HitObject
{
    int randCount;
    int hitCount;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject effect;
    Animator animator;
    float radius = 2f;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        randCount = Random.Range(12, 16);
        hitCount = Random.Range(5, 8);
    }
    public override void OnHit()
    {
        if (CurrentTool.Instance.getTypeTool() == CurrentTool.TypeTool.Axe)
        {
            GameEventSystem.current.HitEvent();
            animator.SetTrigger("Hit");
            hitCount--;

            if (hitCount == 0)
            {
                while (randCount > 0)
                {
                    Instantiate(wood, Random.insideUnitSphere * radius + transform.position, Quaternion.identity);
                    randCount--;
                }

                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);


            }
        }
    }
}
