﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RunChoiceBehaviour : MonoBehaviour
{
    public Text Log_Text;
	public void Run()
    {
        Log_Text.text += "You are now running..." + Environment.NewLine;
    }
	
}
