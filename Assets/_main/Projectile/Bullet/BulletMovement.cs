using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction = Vector2.right;
    float speed;
    Transform self;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        self = transform;
    }

    public void SetDirection(Vector2 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
        Rotate();
    }

    private void Rotate()
    {
        self.rotation = Quaternion.FromToRotation(Vector2.right, direction);
    }

    private void OnEnable()
    {
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnDisable()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
