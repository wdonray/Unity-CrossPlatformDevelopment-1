using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RunChoiceBehaviour : MonoBehaviour
{
    public Text informationText;
	public void Run()
    {
        string info = "Run Choice Selected I am running....";
        informationText.text += info + Environment.NewLine;
    }
	
}
