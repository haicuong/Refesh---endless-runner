using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<bool> OnGround;
    public event Action<float> OnTakeDamage;
    private int groundLayer;

    private void Awake()
    {
        groundLayer = LayerMask.NameToLayer("Ground");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            OnGround?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
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
