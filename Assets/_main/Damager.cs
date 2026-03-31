using UnityEngine;

public class Damager : MonoBehaviour
{
    protected virtual void DealDamage(GameObject gameObject, float damage)
    {
        if (gameObject.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.TakeDamage(damage);
        }
    }
}
