using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> where T : ObjectToPool
{
    readonly Queue<T> pool = new();
    public Queue<T> Pool => pool;
    T _prefab;
    Transform _parent;

    public ObjectPooling(T prefab, int amount, Transform parent = null)
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

    private T CreateObject()
    {
        T newObj = Object.Instantiate(_prefab, _parent);
        newObj.gameObject.SetActive(false);
        if (newObj is ObjectToPool) newObj.Initialize(obj => ReturnToPool(newObj));
        return newObj;
    }

    public T GetObject()
    {
        if (pool.Count > 0)
            return pool.Dequeue();
        return CreateObject();
    }

    /// <summary>
    /// Get object, if no object left, create new and return false
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>There is 1 or more object in pool</returns>
    public bool GetObject(out T obj)
    {
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            return true;
        }
        obj = CreateObject();
        return false;
    }

    public void ReturnToPool(T component)
    {
        pool.Enqueue(component);
        component.gameObject.SetActive(false);
    }
}
