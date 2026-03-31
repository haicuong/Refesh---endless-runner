
using UnityEngine;

public class BulletMediator : MonoBehaviour, IProjectileDataInjection
{
    [SerializeField] ObjectToPool pooler;
    [SerializeField] BulletDamage bulletDamage;
    [SerializeField] BulletMovement bulletMovement;
    [SerializeField] BulletDestroy bulletDestroy;
    [SerializeField] PositionLimitChecker positionLimitChecker;

    public void SetData(ProjectileData data)
    {
        bulletDamage.SetDamage(data.Damage, data.AllyFaction);
        bulletMovement.SetDirection(data.Direction, data.Speed);
        bulletDestroy.SetPenetration(data.Penetration);
    }
    public void SetDamage(float damage, Faction allyFaction)
    {
        bulletDamage.SetDamage(damage, allyFaction);
    }

    public void SetDirection(Vector2 direction, float speed)
    {
        bulletMovement.SetDirection(direction, speed);
    }

    public void SetPenetration(bool penetration)
    {
        bulletDestroy.SetPenetration(penetration);
    }

    private void Awake()
    {
        if (bulletDestroy != null)
        {
            if (bulletDamage != null)
                bulletDamage.OnDamaged += bulletDestroy.OnDamaged;
            if (pooler != null)
                bulletDestroy.OnDestroy += pooler.ReturnToPool;
        }
        if (positionLimitChecker != null && pooler != null)
            positionLimitChecker.OnPositionLimit += pooler.ReturnToPool;
    }
}
