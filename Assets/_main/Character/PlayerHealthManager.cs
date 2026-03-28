using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private int playerHealth;

    private int playerHealthCounter;
    private void Awake()
    {
        playerHealthCounter = playerHealth;
        EventBus<PlayerOnDamage>.Subscribe(OnDamage);
    }
    void OnDamage(PlayerOnDamage onDamage)
    {
        playerHealthCounter--;
        Debug.Log($"Health: {playerHealthCounter}");
        CheckDead();
    }
    void CheckDead()
    {
        if (playerHealthCounter <= 0)
        {
            EventBus<PlayerOnDead>.Publish(new PlayerOnDead());
        }
    }
}
