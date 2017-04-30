using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIBehaviour : UnityEngine.EventSystems.UIBehaviour
{
    public void ToggleGameObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
