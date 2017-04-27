using System;
using UnityEngine;
using UnityEngine.UI;

public class RunChoiceBehaviour : MonoBehaviour
{
    public Text InformationText;
	public void Run()
	{
        InformationText.text = "You are now running..." + Environment.NewLine;
    }
	
}
