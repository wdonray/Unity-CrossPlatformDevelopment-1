using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendChoiceBehavior : MonoBehaviour
{

    public GameObject shieldPrefab;
    public GameObject contentWindow;
    public Text Log_Text;
    public void Defend()
    {
        GameObject go = GameObject.Instantiate(shieldPrefab, contentWindow.transform);
        go.AddComponent<DestroyAfterTime>();
        var sprites = Resources.LoadAll<Sprite>("");
        var randomSprite = Random.Range(0, sprites.Length);
        go.GetComponent<Image>().sprite = sprites[randomSprite];
        Log_Text.text = "You are now defending..." + System.Environment.NewLine;
    }
}
