using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<bool> OnGround;
    public event Action<float> OnTakeDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnGround?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround?.Invoke(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnTakeDamage?.Invoke(1);
        }*/
    }
}
