using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item/Gun")]
public class CombatRifle : Weapon, IShootable
{    
    public GameObject projectilePrefab;
    public float RateOfFire;
    public override void Initialize(GameObject obj)
    {        
        _owner = obj;
    }
    public override void Execute()
    {
        
        Shoot(_owner);
    }

    public void Shoot(GameObject obj)
    {        
        var go = Instantiate(projectilePrefab, obj.transform);
        go.transform.ResetTransformation();
        go.transform.localPosition = new Vector3(0, 0, 0);
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 25f, ForceMode2D.Impulse);
        
    }
}
