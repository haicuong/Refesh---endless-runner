using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float downPower;
    [SerializeField] int maxJump;
    [SerializeField] float bufferJumpTime;
    [SerializeField] float minJumpTimeGap;

    public event Action OnShoot;

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
        ShootInputHandler();
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

    bool InputShoot()
    {
        return Input.GetMouseButtonDown(0);
    }

    bool InputDown()
    {
        return Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow);
    }
    void ShootInputHandler()
    {
        if (!InputShoot()) return;
        OnShoot?.Invoke();
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
        JumpRequest();
    }
    void JumpRequest()
    {
        jumpCounter--;
        jumpRequest++;
    }
    void CancelJumpRequest()
    {
        jumpCounter += jumpRequest;
        jumpRequest = 0;
    }
    void JumpCountReset() => jumpCounter = maxJump;

    float lastJumpTime;
    void Jump()
    {
        if (jumpRequest > 0
            && Time.time - lastJumpTime >= minJumpTimeGap
            && Time.time - jumpInputTime <= bufferJumpTime)
        {
            rb.linearVelocity = Vector2.up * jumpPower;
            jumpRequest--;
            lastJumpTime = Time.time;
        }
        else
        {
            CancelJumpRequest();
        }
    }

    public void OnGround(bool onGround)
    {
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
            JumpRequest();
        }
    }
}
