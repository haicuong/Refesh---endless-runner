using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BulletDamage : Damager
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
        DealDamage(collision.gameObject, damage);
    }

    protected override void DealDamage(GameObject gameObject, float damage)
    {
        if (gameObject.gameObject.TryGetComponent<IDamagable>(out var component) && component.Faction != allyFaction)
        {
            component.TakeDamage(damage);
            OnDamaged?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDamaged?.Invoke();
    }
}
