using UnityEngine;

public class PlayerMediator : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] PlayerHealth healthManager;
    [SerializeField] Shooting shooting;

    private void Awake()
    {
        if (shooting != null && controller != null) controller.OnShoot += shooting.Shoot;
    }
}
