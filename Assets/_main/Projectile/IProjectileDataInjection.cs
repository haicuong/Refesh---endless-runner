using UnityEngine;

public interface IProjectileDataInjection
{
    void SetData(ProjectileData data);
    void SetDirection(Vector2 direction, float speed);
    void SetDamage(float damage, Faction allyFaction);
    void SetPenetration(bool penetration);
}
