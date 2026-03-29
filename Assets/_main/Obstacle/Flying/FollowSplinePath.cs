using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSplinePath : MonoBehaviour
{
    [SerializeField] SplineContainer spline;
    [SerializeField] float duration;

    bool reverse;
    float timeRatio;
    Transform self;
    private void Awake()
    {
        self = GetComponent<Transform>();
    }
    private void Update()
    {
        TimeRatioCounter();
        Move();
    }

    void TimeRatioCounter()
    {
        if (timeRatio <= 0)
        {
            timeRatio = 0;
            reverse = false;
        }
        else if (timeRatio >= 1)
        {
            timeRatio = 1;
            reverse = true;
        }
        if (!reverse)
            timeRatio += Time.deltaTime / duration;
        else timeRatio -= Time.deltaTime / duration;
    }

    Vector2 cachedPosition;
    void Move()
    {
        float3 f3pos = spline.EvaluatePosition(timeRatio);
        Vector2 pos = new(f3pos.x, f3pos.y);
        self.position = new Vector2(pos.x, pos.y);
    }
}
