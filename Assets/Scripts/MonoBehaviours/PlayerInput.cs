using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Awake()
    {
        UserControl = true;
    }

    public static Vector2 LeftStick
    {
        get
        {
            return new Vector2(Input.GetAxis(Strings.LEFTHORIZONTAL), Input.GetAxis(Strings.LEFTVERTICAL));
        }
    }

    public static Vector2 RightStick
    {
        get
        {
            return new Vector2(Input.GetAxis(Strings.RIGHTHORIZONTAL),
            Input.GetAxis(Strings.RIGHTVERTICAL));
        }     
    }

    public static bool isInputBlock
    {
        get { return Input.GetButton(Strings.LEFTBUMPER); }
    }

    public static bool isInputCrouch
    {
        get { return Input.GetAxis(Strings.LEFTVERTICAL) < 0; }
    }

    public static bool UserControl
    {
        get;
        set;
    }

    
        
        
    

}
