using UnityEngine;

public class PoolingObjectMediator : MonoBehaviour
{
    [Header("Pooling")]
    [SerializeField] ObjectToPool pooler;
    [SerializeField] PositionLimitChecker limitChecker;

    protected ObjectToPool Pooler => pooler;
    protected virtual void Awake()
    {
        if (Pooler != null && limitChecker != null)
            limitChecker.OnPositionLimit += Pooler.ReturnToPool;
    }
}
