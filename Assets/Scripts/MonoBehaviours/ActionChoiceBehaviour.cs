using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RadialLayout =  UnityEngine.UI.Extensions.RadialLayout;
public class ActionChoiceBehaviour : MonoBehaviour
{
    public RadialLayout layout;

    public bool up = false;

    public float step = 5f;

    public void RadialLerp()
    {
        up = !up;
        StopAllCoroutines();
        StartCoroutine(Fan(up));
        
    }
    
    IEnumerator Fan(bool up)
    {
        bool condition = (up) ? (layout.MaxAngle < 360) : (layout.MaxAngle > 0);
        if (layout.MaxAngle > 360) layout.MaxAngle = 360;
        else if (layout.MaxAngle <= 0) layout.MaxAngle = 0;
        while (condition)
        {
            if (up) layout.MaxAngle += step;
            else if (!up) layout.MaxAngle -= step;
            
            layout.CalculateRadial();

            if(layout.MaxAngle > 360) layout.MaxAngle = 360;
            else if(layout.MaxAngle < 0) layout.MaxAngle = 0;
            yield return null;
        }

        yield return null;
    }
}
