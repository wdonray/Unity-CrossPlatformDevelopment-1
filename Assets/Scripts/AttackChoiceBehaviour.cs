using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackChoiceBehaviour : MonoBehaviour
{

    public GameObject swordPrefab;
    public GameObject contentWindow;
    public Text Log_Text;

    public void Attack()
    {
        var go = Instantiate(swordPrefab, contentWindow.transform);

        go.AddComponent<DestroyAfterTime>();
        var sprites = Resources.LoadAll<Sprite>("sword_sprites");
        var numsprites = sprites.Length;
        var randomSprite = Random.Range(0, numsprites);
        go.GetComponent<Image>().sprite = sprites[randomSprite];

        Log_Text.text = "You are now attacking with #" + randomSprite + System.Environment.NewLine;
    }
}
