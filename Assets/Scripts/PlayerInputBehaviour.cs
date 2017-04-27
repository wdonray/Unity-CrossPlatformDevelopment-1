using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    [SerializeField] Text _positionText;
    [SerializeField] Vector2 _playerPos;

    void Start()
    {
        _playerPos = Vector2.zero;
    }

    void Update()
    {
        var currentPosition = _playerPos;
        if (Input.GetKeyDown(KeyCode.A))
            _playerPos += Vector2.left;

        if (Input.GetKeyDown(KeyCode.D))
            _playerPos += Vector2.right;

        if (Input.GetKeyDown(KeyCode.W))
            _playerPos += Vector2.up;

        if (Input.GetKeyDown(KeyCode.S))
            _playerPos += Vector2.down;


        if (_playerPos == currentPosition) return;
        if (_positionText == null)
            Debug.LogError("error");
        else
        {
            _positionText.text = _playerPos.ToString();
        }
    }
}