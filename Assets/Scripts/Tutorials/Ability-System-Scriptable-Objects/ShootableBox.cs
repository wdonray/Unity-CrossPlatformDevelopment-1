public class ShootableBox : EntityBase
{
    public override void Damage(int amount)
    {
        var newhealth = health - amount;
        if (newhealth > 0)

            health = newhealth - amount;
    }
}