using System;
using ScriptableAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
///     Controller class for UI
///     Interacts with the UIView and Rest of Game
/// </summary>
public class UIController : MonoBehaviour
{
    public BackPack backPack;
    public UIView view;
    public OnCancel onCancel;
    public OnStart onStart;
    public OnStartButton onStartButton;
    public OnSubmit onSubmit;
    
    [HideInInspector] public Unit Unit;

    

    private void Create()
    {
        foreach (var item in backPack.backPackBase.Items)
        {
            var go = new GameObject(item.Name, typeof(Button), typeof(Image));
            var button = go.GetComponent<Button>();
            var image = go.GetComponent<Image>();
            image.sprite = item.sprite;
            go.transform.SetParent(view.InventoryGrid.transform);
            go.transform.ResetTransformation();
        }
    }

    private void Start()
    {
        onStart.Invoke();
    }

    private void Update()
    {
        if (GetCancel()) onCancel.Invoke();
        if (GetSubmit()) onSubmit.Invoke();
        if (GetStart()) onStartButton.Invoke();
    }
    public void SetHealthSlider(int val)
    {
        Debug.Log("got val " + val);
        view.HealthSlider.value = val;
    }
    public static bool GetCancel()
    {
        return Input.GetButtonDown("Cancel");
    }

    public static bool GetSubmit()
    {
        return Input.GetButtonDown("Submit");
    }

    public static bool GetStart()
    {
        return Input.GetButtonDown("Start");
    }

    [Serializable]
    public class OnCancel : UnityEvent
    {
    }

    [Serializable]
    public class OnSubmit : UnityEvent
    {
    }

    [Serializable]
    public class OnStart : UnityEvent
    {
    }

    [Serializable]
    public class OnStartButton : UnityEvent
    {
    }
}