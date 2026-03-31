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
        BackgroundBasedMovement.OnSpeedMultipleChange += Move;
        Move();

    }
    private void OnDisable()
    {
        BackgroundBasedMovement.OnSpeedMultipleChange -= Move;
        Stop();
    }

    private void Move()
    {
        rb.linearVelocity = BackgroundBasedMovement.SpeedMultiple * speed * Vector2.left;
    }
    private void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
