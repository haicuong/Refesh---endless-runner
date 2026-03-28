using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int initialSpawn;
    [SerializeField] float timeGap;
    [SerializeField] ObjectToPool _prefab;
    private ObjectPooler<ObjectToPool> pool;


    private void Awake()
    {
        pool = new(_prefab, initialSpawn, this.transform);
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 2, timeGap);
    }

    void Spawn()
    {
        ObjectToPool obj = pool.GetObject();
        obj.gameObject.SetActive(true);
    }
}
