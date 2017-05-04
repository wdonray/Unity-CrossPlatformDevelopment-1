namespace ScriptableAssets
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Unit", menuName = "Units/UnitTemplate", order = 1)]
    public class Unit : ScriptableObject
    {
        [HideInInspector]
        public Stats _stats;

        public string Name;

        public UnitType UnitType;
    }

    public enum UnitType
    {
        demon,

        player,

        slime
    }
}