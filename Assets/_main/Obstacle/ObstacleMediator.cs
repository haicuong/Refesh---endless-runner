using UnityEngine;

public class ObstacleMediator : PoolingObjectMediator
{
    [Header("Obstacle")]
    [SerializeField] Health health;

    protected override void Awake()
    {
        base.Awake();
        if (health != null && Pooler != null)
            health.OnDead += Pooler.ReturnToPool;
    }
}
