using System;
using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    private Action<GameObject> _returnToPool;

    public void Initialize(Action<GameObject> returnToPool)
    {
        _returnToPool = returnToPool;
    }

    protected void ReturnToPool()
    {
        _returnToPool?.Invoke(this.gameObject);
    }
}
