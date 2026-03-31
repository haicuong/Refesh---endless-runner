using UnityEngine;

public class PlayerMediator : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] PlayerCollisionHandler collisionHandler;
    [SerializeField] PlayerHealthManager healthManager;
    [SerializeField] Shooting shooting;

    private void Awake()
    {
        if (collisionHandler != null && controller != null)
            collisionHandler.OnGround += controller.OnGround;
        if (shooting != null && controller != null) controller.OnShoot += shooting.Shoot;
    }
}
