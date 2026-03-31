using System;
using UnityEngine;

public class BulletDataInjection : MonoBehaviour, IProjectileDataInjection
{
    public event Action<Vector2, float> OnSetDirection;
    public event Action<float, Faction> OnSetDamage;
    public event Action<bool> OnSetPenetration;
    public void SetData(ProjectileData data)
    {
        OnSetDirection?.Invoke(data.Direction, data.Speed);
        OnSetDamage?.Invoke(data.Damage, data.AllyFaction);
        OnSetPenetration?.Invoke(data.Penetration);
    }

    public void SetDirection(Vector2 direction, float speed)
    {
        OnSetDirection?.Invoke(direction, speed);
    }
    public void SetDamage(float damage, Faction allyFaction)
    {
        OnSetDamage?.Invoke(damage, allyFaction);
    }
    public void SetPenetration(bool penetration)
    {
        OnSetPenetration?.Invoke(penetration);
    }
}
