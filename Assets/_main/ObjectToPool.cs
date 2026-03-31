using System;
using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    private Action<GameObject> _returnToPool;
    private Transform _transform;
    public Transform Transform => _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Initialize(Action<GameObject> returnToPool)
    {
        _returnToPool = returnToPool;
    }

    public void ReturnToPool()
    {
        _returnToPool?.Invoke(gameObject);
    }
}
