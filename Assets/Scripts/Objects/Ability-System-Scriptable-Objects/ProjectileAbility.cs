using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability
{
    private ProjectileShootTriggerable launcher;
    public Rigidbody projectile;
    public float projectileForce = 500f;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileShootTriggerable>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }
}