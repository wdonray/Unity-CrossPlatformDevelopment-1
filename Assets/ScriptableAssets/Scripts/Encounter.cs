using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableAssets
{
    public abstract class Encounter : ScriptableObject
    {
        public abstract void Begin();
        public abstract void End();
        Object Result;
    }
}