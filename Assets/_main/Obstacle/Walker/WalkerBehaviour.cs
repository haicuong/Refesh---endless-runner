using UnityEngine;

public class WalkerBehaviour : ObstacleBehaviour
{
    [SerializeField] Vector2 target;
    [SerializeField] float duration;

    Transform self;
    float elapsedTime;
    Vector2 startPos;
    void Awake()
    {
        self = GetComponent<Transform>();
        startPos = self.position;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        elapsedTime = 0;
    }
    bool entered;
    void Update()
    {
        if (entered) return;
        elapsedTime += Time.deltaTime;
        float ratio = Mathf.Clamp01(elapsedTime / duration);
        float easeOutRatio = 1 - (1f - ratio) * (1f - ratio);
        self.position = Vector2.Lerp(startPos, target, easeOutRatio);
        if (ratio >= 1)
        {
            entered = true;
        }
    }
}
