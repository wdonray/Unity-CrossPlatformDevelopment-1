using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item;
    public string ITEM_NAME;
    public bool RANDOM;
    private Item runtimeItem;
    public int timer;

    public void Initialize()
    {
        var allitems = Resources.LoadAll<Item>("Items");
        var randint = Random.Range(0, allitems.Length - 1);
        if (RANDOM)
            item = allitems[randint];

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