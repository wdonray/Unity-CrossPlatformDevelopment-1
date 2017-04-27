using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackChoiceBehavior : MonoBehaviour
{
    public Text Log_Text;
    public GameObject Sword_Prefab;
    public void Attack()
    {
        Log_Text.text += "You are now attacking..." + Environment.NewLine;
        GameObject g = GameObject.Instantiate(Sword_Prefab, FindObjectOfType<Canvas>().transform);
        g.AddComponent<DestroyAfterTime>();
    }
}
