using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Jump Data")]
    [SerializeField] float jumpPower;
    [SerializeField] float downPower;
    [SerializeField] int maxJump;
    [SerializeField] float bufferJumpTime;
    [SerializeField] float minJumpTimeGap;
    [Header("Testing")]
    [SerializeField] float testSpeedMultiple;

    public event Action OnShoot;

    Rigidbody2D rb;
    int jumpCounter;
    float jumpInputTime;
    float onGroundTime;
    int jumpRequest;
    bool isGround;
    int groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        BackgroundBasedMovement.SetSpeedMultiple(testSpeedMultiple);
        JumpInputHandler();
        DownInputHandler();
        ShootInputHandler();
    }

    private void FixedUpdate()
    {
        Jump();
        DownHandler();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            OnGround(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
            OnGround(false);
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
