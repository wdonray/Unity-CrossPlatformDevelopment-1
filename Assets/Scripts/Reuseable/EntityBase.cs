using UnityEngine;

public abstract class EntityBase : MonoBehaviour, IDamageable
{
    public int health;

    public virtual void Damage(int amount)
    {
    }
}

public interface IDamageable
{
    void Damage(int amt);
}