using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveLeftRig : MonoBehaviour
{
    [SerializeField] private int speed;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
