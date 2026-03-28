using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            EventBus<PlayerOnGround>.Publish(new PlayerOnGround());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EventBus<PlayerOnDamage>.Publish(new PlayerOnDamage());
        }
    }
}
