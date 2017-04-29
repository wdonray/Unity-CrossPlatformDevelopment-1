using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptableAssets
{
    [CreateAssetMenu(fileName = "Student", menuName= "Units/Student", order=3)]
    public class Student : ScriptableObject
    {
        public string Name;
        public string ID;
        public Race Race;
        public int Health;

        public void Fight(Student s)
        {
            s.Health -= 5;
        }
    }

    public enum Race
    {
        hispanic,
        caucasian,
        african,
        pacificphillipino,
    }
}
