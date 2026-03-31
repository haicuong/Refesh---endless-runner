using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkerMovement : MonoBehaviour
{
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 target;
    [SerializeField] float duration;

    public event Action OnEntered;
    public event Action OnExited;

    Rigidbody2D rb;
    float elapsedTime;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        ResetTime();
    }

    void ResetTime() => elapsedTime = 0;
    bool entered;
    void Update()
    {
        Move();
    }

    void Move()
    {
        elapsedTime += Time.deltaTime;
        float ratio = Mathf.Clamp01(elapsedTime / duration);
        float easeRatio = !entered ? 1 - (1f - ratio) * (1f - ratio) : ratio * ratio;
        Vector2 a = !entered ? startPos : target;
        Vector2 b = !entered ? target : startPos;
        SetPosition(a, b, easeRatio);
        if (ratio >= 1)
        {
            entered = !entered;
            if (entered) OnEntered?.Invoke();
            else OnExited?.Invoke();
            ResetTime();
        }
    }

    void SetPosition(Vector2 startPos, Vector2 target, float ratio)
    {
        rb.MovePosition(Vector2.Lerp(startPos, target, ratio));
    }
}
