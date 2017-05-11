using UnityEngine;

[CreateAssetMenu(menuName = "Item/ShotGun")]
public class CombatShotgun : Weapon, IShootable
{
    readonly int numPellets = 5;
    public GameObject projectilePrefab;

    public void Shoot(GameObject obj)
    {
        for (var i = 0; i < numPellets; i++)
        {
            var go = Instantiate(projectilePrefab, obj.transform);
            go.transform.ResetTransformation();
            go.transform.localPosition += new Vector3(0, i + 5f, 0);
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
        }
    }

    public override void Initialize(GameObject obj)
    {
        _owner = obj;
    }

    public override void Execute()
    {
        Shoot(_owner);
    }
}