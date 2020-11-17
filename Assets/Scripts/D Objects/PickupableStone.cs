using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableStone : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] Inventory inventory;
    private Item item;

    private void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, collision.transform.position);
            if (distance < 0.1f)
            {
                InventoryHolder.Instance.inventory.AddItem(new Item { itemType = Item.ItemType.Stone, amount = 1 });
                Destroy(gameObject);
            }

        }
    }

}
