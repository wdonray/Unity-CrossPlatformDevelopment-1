using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{        
    public List<GameObject> IgnoredColliders;
    public GameObject RootObject;

    public ShieldConfig _ShieldConfig;

    public IBlockable CurrentShield;

    public void Initialize()
    {
        _ShieldConfig = Instantiate(_ShieldConfig);       
        _ShieldConfig.Initialize(this.gameObject);
        CurrentShield = _ShieldConfig;
                
        IgnoredColliders.Add(RootObject);

        foreach (var collider in RootObject.GetComponentsInChildren<Collider2D>())
        {
            if (collider != this.GetComponent<Collider2D>())
            {
                IgnoredColliders.Add(collider.gameObject);
            }
        }        
    }    

    public void DoBlock(GameObject go)
    {
        if (IgnoredColliders.Contains(go))
            return;
        CurrentShield.Block();
    }
    
    public void StopBlock(GameObject go)
    {
        if (IgnoredColliders.Contains(go))
            return;
        CurrentShield.StopBlock();
    }    
}
