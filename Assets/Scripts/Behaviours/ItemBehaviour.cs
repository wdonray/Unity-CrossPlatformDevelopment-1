using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item_config;
    private Item item_runtime;
    public string ITEM_NAME;
    public bool RANDOM;
    public int Timer;
    private bool _initialized = false;
    public void Initialize()
    {
        if (_initialized)
        {
            Debug.LogWarning("attempting to initialize an already initialized item behaviour");
            return;
        }
        
        var allitems = Resources.LoadAll<Item>("Items");
        var randint = Random.Range(0, allitems.Length - 1);
        if (RANDOM)
            item_config = allitems[randint];

        item_runtime = Instantiate(item_config);
        item_runtime.Initialize(null);

        item_runtime.ItemSprite = item_config.ItemSprite;
        ITEM_NAME = item_runtime.DisplayName;

        GetComponent<SpriteRenderer>().sprite = item_runtime.ItemSprite;
        _initialized = true;
    }

    public void AddToBackpack(GameObject go)
    {
        Debug.Log("add to pack");
        go.GetComponentInParent<BackPackBehaviour>().AddToPack(item_runtime);
    }

    public void DestroyItemGameObject()
    {
        Destroy(gameObject, Timer);
    }
}