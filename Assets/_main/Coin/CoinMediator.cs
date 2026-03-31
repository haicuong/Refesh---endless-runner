using UnityEngine;

public class CoinMediator : MonoBehaviour
{
    [SerializeField] CoinBehaviour coinBehaviour;
    [SerializeField] ObjectToPool pooler;

    private void Awake()
    {
        if (coinBehaviour != null && pooler != null)
        {
            coinBehaviour.OnDestroy += pooler.ReturnToPool;
        }
    }
}
