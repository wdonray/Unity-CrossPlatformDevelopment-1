using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public int timer;
    public Item item;
    private Item runtimeItem;
    public string ITEM_NAME;

    public void Initialize()
    {
        runtimeItem = Instantiate(item);
        runtimeItem.Initialize(null);

        runtimeItem.sprite = item.sprite;
        ITEM_NAME = runtimeItem.Name;

        GetComponent<SpriteRenderer>().sprite = runtimeItem.sprite;
    }
    
    public void AddToBackpack(GameObject go)
    {
        Debug.Log("add to pack");
        go.GetComponentInParent<BackPackBehaviour>().AddToPack(runtimeItem);
    }

    public void DestroyItemGameObject()
    {
        Destroy(gameObject, timer);
    }
}