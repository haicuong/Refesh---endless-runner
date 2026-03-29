using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] protected Vector2 position;

    protected virtual void OnEnable()
    {
        SetPosition();
    }

    protected virtual void SetPosition()
    {
        transform.position = position;
    }
}
