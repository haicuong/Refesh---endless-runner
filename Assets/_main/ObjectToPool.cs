using System;
using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    private Action<GameObject> _returnToPool;

    public void Initialize(Action<GameObject> returnToPool)
    {
        _returnToPool = returnToPool;
    }

    public void ReturnToPool()
    {
        _returnToPool?.Invoke(this.gameObject);
    }
}
