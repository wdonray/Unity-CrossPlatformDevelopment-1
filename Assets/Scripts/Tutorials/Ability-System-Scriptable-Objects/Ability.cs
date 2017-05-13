using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public float aBaseCoolDown = 1f;

    public string aName = "New Ability";
    public AudioClip aSound;
    public Sprite aSprite;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}