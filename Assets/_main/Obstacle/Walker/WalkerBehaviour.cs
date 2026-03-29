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
        startPos = self.position;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        elapsedTime = 0;
    }

    void ResetTime() => elapsedTime = 0;
    bool entered;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float ratio = Mathf.Clamp01(elapsedTime / duration);
        float easeOutRatio = 1 - (1f - ratio) * (1f - ratio);
        if (!entered)
            SetPosition(startPos, target, easeOutRatio);
        else SetPosition(target, startPos, easeOutRatio);
        if (ratio >= 1)
        {
            entered = !entered;
            ResetTime();
        }
    }

    void SetPosition(Vector2 startPos, Vector2 target, float easeOutRatio)
    {
        self.position = Vector2.Lerp(startPos, target, easeOutRatio);

    }
}
