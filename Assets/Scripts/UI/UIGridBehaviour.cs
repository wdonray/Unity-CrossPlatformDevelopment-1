using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class UIGridBehaviour : MonoBehaviour
{
    public Item _item;

    public int Capacity = 16;
    public List<Transform> children = new List<Transform>();
    GameObject firstAvailable;
    int itemIndex = 1;
    int numItems;
    public List<GameObject> ui_items = new List<GameObject>();


    public GameObject FirstAvailable
    {
        get
        {
            firstAvailable = children.First(c => c.childCount <= 0 && c.parent == transform).gameObject;
            return firstAvailable;
        }
    }

    void Awake()
    {
        GetComponentsInChildren(true, children);
    }

    public void SetItem(Item item)
    {
        _item = item;
        SetItem();
    }

    void SetItem()
    {
        var newtotal = numItems + 1;

        if (newtotal > Capacity)
            return;
        var itemgo = new GameObject("Item", typeof(Image), typeof(Selectable));
        ui_items.Add(itemgo);
        itemgo.transform.SetParent(children[itemIndex]);
        itemgo.GetComponent<RectTransform>().Stretch();
        itemgo.GetComponent<Image>().sprite = _item.sprite;
        numItems++;
        itemIndex++;
    }
}