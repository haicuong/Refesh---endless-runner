using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    public event Action<int> OnCoinCollect;

    int coins;
    int coinLayer;

    private void Awake()
    {
        coinLayer = LayerMask.NameToLayer("Coin");
        OnCoinCollect += CoinDebug;
    }

    void CoinDebug(int coin)
    {
        Debug.Log($"Get a coin!\nTotal coins: {coins}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == coinLayer)
        {
            coins++;
            OnCoinCollect?.Invoke(coins);
        }
    }
}
