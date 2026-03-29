using UnityEngine;

public class ObstacleBehaviour : ObjectToPool
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLimit")) ReturnToPool();
    }
}
