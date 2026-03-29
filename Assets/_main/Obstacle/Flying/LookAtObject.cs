using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationUpdateRate = 0.03f;

    Transform _self;
    Vector2 cachedDirection;

    private void Awake()
    {
        _self = transform;
    }

    private void Update()
    {
        RotateUpdate();
    }
    void RotateUpdate()
    {
        Vector2 direction = (target.position - _self.position).normalized;
        Debug.Log("Rate: " + (direction - cachedDirection).sqrMagnitude);
        if ((direction - cachedDirection).sqrMagnitude >= rotationUpdateRate * rotationUpdateRate)
        {
            Rotate(direction);
            cachedDirection = direction;
        }
    }
    void Rotate(Vector2 direction)
    {
        _self.rotation = Quaternion.FromToRotation(Vector2.right, direction);
    }
}
