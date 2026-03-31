
using UnityEngine;

public class PlayerHealth : Health
{
    private void Awake()
    {
        OnHealthChange += HealthDebug;
    }
    void HealthDebug(float health)
    {
        Debug.Log($"Player health: {health}");
    }
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
