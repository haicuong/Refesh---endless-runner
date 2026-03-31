using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PositionLimitChecker : MonoBehaviour
{
    private int wallLimitLayer;
    public event Action OnPositionLimit;

    private void Awake()
    {
        wallLimitLayer = LayerMask.NameToLayer("WallLimit");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == wallLimitLayer)
            OnPositionLimit?.Invoke();
    }
}
