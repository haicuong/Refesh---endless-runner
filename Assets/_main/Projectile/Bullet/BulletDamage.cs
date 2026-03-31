using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BulletDamage : MonoBehaviour
{
    Faction allyFaction;
    float damage;

    public event Action OnDamaged;

    public void SetDamage(float damage, Faction allyFaction)
    {
        this.damage = damage;
        this.allyFaction = allyFaction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out var component) && component.Faction != allyFaction)
        {
            component.TakeDamage(damage);
            OnDamaged?.Invoke();
        }
    }
}
