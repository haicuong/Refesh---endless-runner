using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance => instance;

    private void Awake()
    {
        instance = this;
    }
}
