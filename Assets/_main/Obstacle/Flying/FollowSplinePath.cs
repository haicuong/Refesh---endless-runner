using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowSplinePath : MonoBehaviour
{
    [SerializeField] SplineContainer spline;
    [SerializeField] float duration;

    bool reverse;
    float timeRatio;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        TimeRatioCounter();
        Move();
    }

    void TimeRatioCounter()
    {
        float step = Time.deltaTime / duration;
        timeRatio += !reverse ? step : -step;
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
    }

    Vector2 cachedPosition;
    void Move()
    {
        float3 f3pos = spline.EvaluatePosition(timeRatio);
        Vector2 pos = new(f3pos.x, f3pos.y);
        rb.MovePosition(new Vector2(pos.x, pos.y));
    }
}
