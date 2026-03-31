using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] Transform shooter;
    [SerializeField] ObjectToPool bullet;
    [SerializeField] GameObject parentPool;
    [SerializeField] int initialBulletAmount;
    [SerializeField] float bulletStartRange;

    [Header("Direction")]
    [SerializeField] Vector2 target;
    [SerializeField] float speed;

    [Header("Damage")]
    [SerializeField] float damage;
    [SerializeField] Faction allyFaction;
    [SerializeField] bool piercing;

    public event Action OnProjectileDataChange;

    private ObjectPooling<ObjectToPool> pooling;
    protected ProjectileData projectileData;
    private void Awake()
    {
        pooling = new(bullet, initialBulletAmount, parentPool.transform);
        SetProjectileData();
        InjectDataAll();
        OnProjectileDataChange += InjectDataAll;
    }

    protected virtual void SetProjectileData()
    {
        projectileData = new ProjectileData
        {
            Direction = Vector2.right,
            Speed = speed,
            Damage = damage,
            AllyFaction = allyFaction,
            Penetration = piercing,
        };
    }

    protected virtual void SetDirection(Vector2 direction, float speed)
    {
        projectileData.Direction = direction;
        projectileData.Speed = speed;
        OnProjectileDataChange?.Invoke();
    }

    protected virtual void SetDamage(float damage, Faction allyFaction)
    {
        projectileData.Damage = damage;
        projectileData.AllyFaction = allyFaction;
        OnProjectileDataChange?.Invoke();
    }

    protected virtual void SetPiercing(bool piercing)
    {
        projectileData.Penetration = piercing;
        OnProjectileDataChange?.Invoke();
    }

    protected virtual void InjectDataAll()
    {
        foreach (var bullet in pooling.Pool)
        {
            InjectData(bullet, projectileData);
        }
    }

    protected virtual void InjectData(ObjectToPool bullet, ProjectileData projectileData)
    {
        if (bullet.TryGetComponent<IProjectileDataInjection>(out var projectile))
        {
            projectile.SetData(projectileData);
        }
    }

    protected virtual void InjectDataAll(ProjectileData projectileData)
    {
        foreach (var bullet in pooling.Pool)
        {
            InjectData(bullet, projectileData);
        }
    }
    public void Shoot()
    {
        if (!pooling.GetObject(out ObjectToPool bullet))
            InjectData(bullet, projectileData);
        bullet.Transform.position = (Vector2)shooter.position + projectileData.Direction * bulletStartRange;
        bullet.gameObject.SetActive(true);
    }
}
