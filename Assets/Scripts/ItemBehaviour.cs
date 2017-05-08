using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item;
    public Item runtimeItem;

    private void Start()
    {
        var s = ScriptableObject.CreateInstance(item.GetType());
        runtimeItem = (Item) s;
        runtimeItem.Initialize(null);
        runtimeItem.sprite = item.sprite;
        GetComponent<SpriteRenderer>().sprite = item.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<BackPack>().Add(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<BackPack>().Add(item);
            Destroy(gameObject);
        }
    }
}