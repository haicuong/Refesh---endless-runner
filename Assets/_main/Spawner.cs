using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Data")]
    [SerializeField] int initialSpawn;
    [SerializeField] float timeGap;
    [SerializeField] ObjectToPool _prefab;
    private ObjectPooling<ObjectToPool> pool;


    private void Awake()
    {
        pool = new(_prefab, initialSpawn, this.transform);
    }

    protected virtual void Start()
    {
        InvokeRepeating("Spawn", 2, timeGap);
    }

    protected virtual void Spawn()
    {
        ObjectToPool obj = pool.GetObject();
        obj.gameObject.SetActive(true);
    }
}
