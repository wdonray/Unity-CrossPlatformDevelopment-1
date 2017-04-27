
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    [SerializeField]
    Text positionText;
    Vector2 PlayerPos;
    void Start()
    {
        PlayerPos = Vector2.zero;
    }
    void Update()
    {
        var currentPosition = PlayerPos;
        if(Input.GetKeyDown(KeyCode.A))
            PlayerPos += Vector2.left;

        if(Input.GetKeyDown(KeyCode.D))
            PlayerPos += Vector2.right;

        if(Input.GetKeyDown(KeyCode.W))
            PlayerPos += Vector2.up;

        if(Input.GetKeyDown(KeyCode.S))
            PlayerPos += Vector2.down;


        if(PlayerPos != currentPosition)
        {
            if(positionText == null)
                Debug.LogError("error");
            else
            {
                positionText.text = PlayerPos.ToString();
            }
            
        }
            
    }


}
