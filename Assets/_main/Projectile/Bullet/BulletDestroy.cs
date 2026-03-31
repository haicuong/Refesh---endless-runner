using System;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    bool penetration;
    public event Action OnDestroy;

    public void SetPenetration(bool penetration) => this.penetration = penetration;

    public void OnDamaged()
    {
        if (!penetration) OnDestroy?.Invoke();
    }
}
