public class PlayerHealthManager : Health
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        EventBus<PLayerOnHealthChange>.Publish(new PLayerOnHealthChange(health));
    }
    protected override void CheckDead(float health)
    {
        base.CheckDead(health);
        if (health <= 0) EventBus<PlayerOnDead>.Publish(new PlayerOnDead());
    }
}
