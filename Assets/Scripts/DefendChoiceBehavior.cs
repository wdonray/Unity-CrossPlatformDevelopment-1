using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DefendChoiceBehavior : MonoBehaviour {

    public Text Log_Text;
    public void Defend()
    {
        Log_Text.text += "You are now defending..." + Environment.NewLine;
    }
}
