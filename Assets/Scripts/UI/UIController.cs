using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Controller class for UI
/// Interacts with the UIView and Rest of Game
/// </summary>
public class UIController : MonoBehaviour
{
    [System.Serializable]
    public class OnCancel : UnityEvent { }
    [System.Serializable]
    public class OnSubmit : UnityEvent { }

    public ScriptableAssets.Unit Unit;
    public OnSubmit onSubmit;
    public OnCancel onCancel;
    public UIView view;
    [ContextMenu("create")]
    private void Create()
    {
        foreach(var item in backPack.Items)
        {
            var go = new GameObject(item.Name);
            var button = go.AddComponent<Button>();
            var image = go.AddComponent<Image>();
            image.sprite = item.sprite;
            go.transform.SetParent(view.InventoryGrid.transform);
            go.transform.ResetTransformation();

        }
    }
    private void Update()
    {
        if(GetCancel()) onCancel.Invoke();
        if(GetSubmit()) onSubmit.Invoke();
    }
    public static bool GetCancel()
    {
        return Input.GetButtonDown("Cancel");
    }

    public static bool GetSubmit()
    {
        return Input.GetButtonDown("Submit");
    }

    public BackPack backPack;
}
