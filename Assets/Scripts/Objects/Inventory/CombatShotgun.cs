using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item/ShotGun")]
public class CombatShotgun : Weapon, IShootable
{  
    public GameObject projectilePrefab;
    int numPellets = 5;
    public override void Initialize(GameObject obj)
    {
        
        this._owner = obj;
    }
    public override void Execute()
    {        
        Shoot(this._owner);
    }
    public void Shoot(GameObject obj)
    {
        for(int i = 0; i < numPellets; i++)
        {
            var go = Instantiate(projectilePrefab, obj.transform);
            go.transform.ResetTransformation();
            go.transform.localPosition += new Vector3(0, i + 5f, 0);
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
            
        }
    }
}
