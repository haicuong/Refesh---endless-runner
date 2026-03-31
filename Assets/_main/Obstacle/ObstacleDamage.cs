using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class ObstacleDamage : Damager
{
    [SerializeField] private float damage;

    private int playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != playerLayer) return;
        DealDamage(collision.gameObject, damage);
    }

    public void SetDamage(float damage) => this.damage = damage;
}