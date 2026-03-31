using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PositionLimitChecker : MonoBehaviour
{
    public event Action OnPositionLimit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("WallLimit"))
            OnPositionLimit?.Invoke();
    }
}
