using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item;

    Item runtimeItem;

    public string ITEM_NAME;
    
    void Start()
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
        go.GetComponentInParent<BackPack>().AddToPack(item);
    }

    public void DestroyItemGameObject()
    {
        Destroy(gameObject, 3);
    }
}