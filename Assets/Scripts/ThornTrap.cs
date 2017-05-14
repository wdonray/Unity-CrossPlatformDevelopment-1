using UnityEngine;

public class ThornTrap : MonoBehaviour
{
    private GenericModifier RUNTIME_MOD;
    public GenericModifier ThornModConfig;
    
    public void Initialize()
    {
        RUNTIME_MOD = Instantiate(ThornModConfig);
        RUNTIME_MOD.Initialize(null);
    }

    public void DoDamage(GameObject go)
    {
        Debug.Log("collide with player");
        go.GetComponent<PlayerBehaviour>().ModifyStat(RUNTIME_MOD.EffectedStatType.ToString(), RUNTIME_MOD.TheMod);
        Destroy(gameObject);
    }
}