using System;
using UnityEngine;

public interface IDamagable
{
    public void TakeDamage(float damage);
}
public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;

    public event Action<float> OnHealthChange;
    public event Action OnDead;

    protected float health;

    private void OnEnable()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health); ;
        Debug.Log($"Health: {health}");
        OnHealthChange?.Invoke(health);
        CheckDead(health);
    }
    public virtual void Heal(float healHealth)
    {
        health = Mathf.Clamp(health + healHealth, health, maxHealth);
        OnHealthChange?.Invoke(health);
    }
    protected virtual void CheckDead(float health)
    {
        if (health <= 0) OnDead?.Invoke();
    }
}
