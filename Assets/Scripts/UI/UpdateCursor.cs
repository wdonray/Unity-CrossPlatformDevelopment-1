using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCursor : UIBehaviour
{
    private RectTransform rectTransform;

    protected override void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(FindObjectOfType<UnityEngine.UI.Button>().gameObject);

        Current = EventSystem.current.currentSelectedGameObject;
        

    }
    
    public GameObject current;
    private void Update()
    {
        if(FindObjectOfType<Canvas>().isActiveAndEnabled)
        {
            Time.timeScale = 0;
            FindObjectOfType<PlayerMovementBehaviour>().enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            FindObjectOfType<PlayerMovementBehaviour>().enabled = true;
        }
            
        if(EventSystem.current.currentSelectedGameObject != current)
        {
            Current = EventSystem.current.currentSelectedGameObject;
            
        }
    }

    private void ResetPosition()
    {
        rectTransform.SetParent(current.transform);
        var rect = current.GetComponent<RectTransform>().rect;
        rectTransform.localPosition = new Vector3(rect.xMin, rect.yMin, 0); ;
    }

    public GameObject Current
    {
        get { return current; }
        set
        {
            current = value;
            ResetPosition();
        }
    }
}


