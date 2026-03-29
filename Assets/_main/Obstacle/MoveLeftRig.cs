using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(ObjectToPool))]
public class MoveLeftRig : MonoBehaviour
{
    [SerializeField] private int speed;

    Rigidbody2D rb;
    ObjectToPool pooler;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pooler = GetComponent<ObjectToPool>();
    }

    private void OnEnable()
    {
        Move();
    }
    private void OnDisable()
    {
        Stop();
    }

    private void Move()
    {
        rb.linearVelocity = Vector2.left * speed;
    }
    private void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLimit")) pooler.ReturnToPool();
    }
}
