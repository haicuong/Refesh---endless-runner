using UnityEngine;

public class AutoSetPosition : MonoBehaviour
{
    [SerializeField] protected Vector2 spawnPosition;

    private Transform self;
    protected virtual void Awake()
    {
        self = GetComponent<Transform>();
    }
    protected virtual void OnEnable()
    {
        SetPosition();
    }

    protected virtual void SetPosition()
    {
        self.position = spawnPosition;
    }
}
