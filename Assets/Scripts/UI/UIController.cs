using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [System.Serializable]
    public class OnCancel : UnityEvent { }
    [System.Serializable]
    public class OnSubmit : UnityEvent { }

    public ScriptableAssets.Unit Unit;
    public OnSubmit onSubmit;
    public OnCancel onCancel;
    
    private void Update()
    {
        if (GetCancel()) onCancel.Invoke();
        if (GetSubmit()) onSubmit.Invoke();
    }
    public static bool GetCancel()
    {
        return Input.GetButtonDown("Cancel");
    }

    public static bool GetSubmit()
    {
        return Input.GetButtonDown("Submit");
    }


}
