using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<T> where T : ObjectToPool
{
    Queue<T> pool = new();
    T _prefab;
    Transform _parent;

    public ObjectPooler(T prefab, int amount, Transform parent = null)
    {
        _prefab = prefab;
        _parent = parent;
        for (int i = 0; i < amount; i++)
        {
            T newObj = Object.Instantiate(prefab, parent);
            newObj.gameObject.SetActive(false);
            if (newObj is ObjectToPool) newObj.Initialize(obj => ReturnToPool(newObj));
            pool.Enqueue(newObj);
        }
    }

    private void CreateObject()
    {
        T newObj = Object.Instantiate(_prefab, _parent);
        newObj.gameObject.SetActive(false);
        if (newObj is ObjectToPool) newObj.Initialize(obj => ReturnToPool(newObj));
        pool.Enqueue(newObj);
    }

    public T GetObject()
    {
        if (pool.Count > 0)
            return pool.Dequeue();
        CreateObject();
        return pool.Dequeue();
    }

    public void ReturnToPool(T component)
    {
        pool.Enqueue(component);
        component.gameObject.SetActive(false);
    }
}
