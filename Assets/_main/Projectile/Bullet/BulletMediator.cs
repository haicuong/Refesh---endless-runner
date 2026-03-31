
using UnityEngine;

public class BulletMediator : MonoBehaviour
{
    [SerializeField] ObjectToPool pooler;
    [SerializeField] BulletDamage bulletDamage;
    [SerializeField] BulletMovement bulletMovement;
    [SerializeField] BulletDestroy bulletDestroy;
    [SerializeField] BulletDataInjection dataInjection;
    [SerializeField] PositionLimitChecker positionLimitChecker;

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
        if (dataInjection != null)
        {
            if (bulletMovement != null)
            {
                dataInjection.OnSetDirection += bulletMovement.SetDirection;
            }
            if (bulletDamage != null) dataInjection.OnSetDamage += bulletDamage.SetDamage;
            if (bulletDestroy != null) dataInjection.OnSetPenetration += bulletDestroy.SetPenetration;

        }
    }
}
