using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float downPower;
    [SerializeField] int maxJump;
    [SerializeField] float bufferJumpTime;
    [SerializeField] float minJumpTimeGap;

    Rigidbody2D rb;
    int jumpCounter;
    float jumpInputTime;
    float onGroundTime;
    int jumpRequest;
    bool isGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //EventBus<PlayerOnGround>.Subscribe(OnGround);
        //EventBus<PlayerLeaveGround>.Subscribe(LeaveGround);
    }

    private void Update()
    {
        JumpInputHandler();
        DownInputHandler();
    }

    private void FixedUpdate()
    {
        Jump();
        DownHandler();
    }

    bool InputJump()
    {
        return Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow);
    }

    bool InputDown()
    {
        return Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow);
    }
    void DownInputHandler()
    {
        if (!InputDown()) return;
        if (isGround) return;
        downRequest = true;
    }

    bool downRequest;
    void DownHandler()
    {
        if (downRequest)
        {
            rb.linearVelocity = Vector2.down * downPower;
            downRequest = false;
        }
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
        if (jumpRequest > 0 && Time.time - lastJumpTime >= minJumpTimeGap)
        {
            rb.linearVelocity = Vector2.up * jumpPower;
            jumpRequest--;
            lastJumpTime = Time.time;
        }
    }

    public void OnGround(bool onGround)
    {
        Debug.Log($"On ground: {onGround}");
        isGround = onGround;
        if (!isGround) return;
        JumpCountReset();
        JumpBufferCheck();
    }

    void JumpBufferCheck()
    {
        onGroundTime = Time.time;
        if (onGroundTime - jumpInputTime <= bufferJumpTime)
        {
            JumpHandler();
        }
    }
}
