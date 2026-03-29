using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] int maxJump;
    [SerializeField] float bufferJumpTime;
    [SerializeField] float minJumpTimeGap;

    Rigidbody2D rb;
    int jumpCounter;
    float jumpInputTime;
    float onGroundTime;
    int jumpRequest;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EventBus<PlayerOnGround>.Subscribe(OnGround);
    }

    private void Update()
    {
        JumpInputHandler();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    bool InputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    void JumpInputHandler()
    {
        if (!InputJump()) return;
        jumpInputTime = Time.time;
        if (jumpCounter <= 0) return;
        JumpHandler();
    }
    void JumpHandler()
    {
        jumpCounter--;
        jumpRequest++;
    }
    void JumpCountReset() => jumpCounter = maxJump;

    float lastJumpTime;
    void Jump()
    {
        Debug.Log($"Jump Request: {jumpRequest}");
        if (jumpRequest > 0 && Time.time - lastJumpTime >= minJumpTimeGap)
        {
            rb.linearVelocity = Vector2.up * jumpPower;
            jumpRequest--;
            lastJumpTime = Time.time;
        }
    }

    void OnGround(PlayerOnGround playerOnGround)
    {
        onGroundTime = Time.time;
        JumpCountReset();
        if (onGroundTime - jumpInputTime <= bufferJumpTime)
        {
            JumpHandler();
        }
    }
}
