using UnityEngine;

public class ObstacleMediator : MonoBehaviour
{
    [SerializeField] ObjectToPool pooler;
    [SerializeField] PositionLimitChecker limitChecker;
    [SerializeField] Health health;

    private void Awake()
    {
        if (pooler != null && limitChecker != null)
            limitChecker.OnPositionLimit += pooler.ReturnToPool;
        if (health != null && pooler != null)
            health.OnDead += pooler.ReturnToPool;
    }
}
