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
        if(EventSystem.current.currentSelectedGameObject != current)
            Current = EventSystem.current.currentSelectedGameObject;

    }

    private void ResetPosition()
    {
        rectTransform.SetParent(current.transform);
        var rect = current.GetComponent<RectTransform>().rect;
        rectTransform.localPosition = new Vector3(rect.xMin, rect.yMin/rect.height, 0);
        
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


