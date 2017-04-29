using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Student = ScriptableAssets.Student;

public class StudentBehaviour : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    public Student student;
    public Student target;
    public void Start()
    {
        text.text = "Name:" + student.name + "HP:" + student.Health;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            student.Fight(target);
            text.text = "Name:" + student.name + "HP:" + student.Health;
        }
    }
}
