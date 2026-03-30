using UnityEngine;

public class WalkerBehaviour : ObstacleBehaviour
{
    [SerializeField] Vector2 target;
    [SerializeField] float duration;

    float elapsedTime;
    Vector2 startPos;
    protected override void Awake()
    {
        base.Awake();
        startPos = position;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
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
        float easeRatio = !entered? 1 - (1f - ratio) * (1f - ratio) : ratio*ratio;
        Vector2 a = !entered? startPos : target;
        Vector2 b = !entered? target : startPos;
        SetPosition(a, b, easeRatio);
        if (ratio >= 1)
        {
            entered = !entered;
            ResetTime();
        }
    }

    void SetPosition(Vector2 startPos, Vector2 target, float ratio)
    {
        self.position = Vector2.Lerp(startPos, target, ratio);
    }
}
