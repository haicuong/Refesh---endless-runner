using UnityEngine;

public class PlayerMediator : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] PlayerCollisionHandler collisionHandler;
    [SerializeField] PlayerHealthManager healthManager;

    private void Awake()
    {
        if (collisionHandler != null && controller != null)
            collisionHandler.OnGround += controller.OnGround;
        if (healthManager != null && collisionHandler != null)
            collisionHandler.OnTakeDamage += healthManager.TakeDamage;
    }
}
