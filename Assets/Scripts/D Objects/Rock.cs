using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : HitObject
{
    int randCount;
    int hitCount;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject effect;
    Animator animator;
    float radius = 1f;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        randCount = Random.Range(3, 6);
        hitCount = Random.Range(5, 8);
    }

    public override void OnHit()
    {
        if (CurrentTool.Instance.getTypeTool() == CurrentTool.TypeTool.PickAxe)
        {
            GameEventSystem.current.HitEvent(); //animator.ResetTrigger("Hit");
            animator.SetTrigger("Hit");
            Debug.Log("Hit");
            hitCount--;

            if (hitCount == 0)
            {
                while (randCount > 0)
                {
                    Instantiate(stone, Random.insideUnitSphere * radius + transform.position, Quaternion.identity);
                    randCount--;
                }

                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
