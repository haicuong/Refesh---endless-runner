using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleBehaviour : ObjectToPool
{
    [SerializeField] private int speed;
    [SerializeField] private Vector2 position;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        transform.position = position;
        rb.linearVelocity = Vector2.left * speed;
    }
    private void OnDisable()
    {
        rb.linearVelocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLimit")) ReturnToPool();
    }
}
