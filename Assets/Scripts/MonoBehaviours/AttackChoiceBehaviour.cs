using UnityEngine;
using UnityEngine.UI;

public class AttackChoiceBehaviour : MonoBehaviour
{
    public GameObject SwordPrefab;
    public GameObject ContentWindow;

    public void Attack()
    {
        var go = Instantiate(SwordPrefab, ContentWindow.transform);

        go.AddComponent<DestroyOnTimer>();
        var sprites = Resources.LoadAll<Sprite>("sword_sprites");
        var numsprites = sprites.Length;
        var randomSprite = Random.Range(0, numsprites);
        go.GetComponent<Image>().sprite = sprites[randomSprite];
    }
}