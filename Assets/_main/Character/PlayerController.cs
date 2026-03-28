using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private int maxJump;

    private Rigidbody2D rb;
    private bool onJump;
    private int jumpCounter;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EventBus<PlayerOnGround>.Subscribe(OnGround);
    }

    private void Update()
    {
        Debug.Log($"Jump left: {jumpCounter}");
        JumpHandler();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    bool InputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    void JumpHandler()
    {
        if (!InputJump()) return;
        if (jumpCounter <= 0) return;
        onJump = true;
        jumpCounter -= 1;
    }

    void Jump()
    {
        if (onJump)
        {
            rb.linearVelocity = Vector2.up * jumpPower;
            onJump = false;
        }
    }

    void OnGround(PlayerOnGround playerOnGround)
    {
        jumpCounter = maxJump;
    }
}
