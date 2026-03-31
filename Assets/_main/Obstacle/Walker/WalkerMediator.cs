using UnityEngine;

public class WalkerMediator : MonoBehaviour
{
    [SerializeField] ObjectToPool pooler;
    [SerializeField] Health health;
    [SerializeField] WalkerMovement walkerMovement;
    [SerializeField] Shooting shooting;

    private void Awake()
    {
        if (walkerMovement != null)
        {
            if (shooting != null)
                walkerMovement.OnEntered += shooting.Shoot;
            if (pooler != null)
                walkerMovement.OnExited += pooler.ReturnToPool;
        }
        if (health != null && pooler != null)
        {
            health.OnDead += pooler.ReturnToPool;
        }
    }
}
