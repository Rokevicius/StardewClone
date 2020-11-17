using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupablePlant : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] Inventory inventory;
    private Item item;

    private void Start()
    {
        inventory = InventoryHolder.Instance.inventory;
    }
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
                inventory.AddItem(new Item { itemType = Item.ItemType.Seeds, amount = 1 });
                Destroy(gameObject);
            }

        }
    }

}
