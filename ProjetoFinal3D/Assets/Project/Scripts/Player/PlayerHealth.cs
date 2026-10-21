using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float invulnerabilityDuration = 1f;

    [Header("Componentes desativados ao morrer")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerShooter shooter;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;
    public bool IsDead => CurrentHealth <= 0;

    public event Action<int, int> HealthChanged;
    public event Action Died;

    private float nextDamageTime;

    private void Awake()
    {
        maxHealth = Mathf.Max(1, maxHealth);
        CurrentHealth = maxHealth;

        if (movement == null)
        {
            movement = GetComponent<PlayerMovement>();
        }

        if (shooter == null)
        {
            shooter = GetComponent<PlayerShooter>();
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || IsDead || Time.time < nextDamageTime)
        {
            return;
        }

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        nextDamageTime = Time.time + invulnerabilityDuration;

        Debug.Log($"Vida: {CurrentHealth}/{maxHealth}", this);
        HealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (movement != null)
        {
            movement.enabled = false;
        }

        if (shooter != null)
        {
            shooter.enabled = false;
        }

        Debug.Log("Jogador morreu.", this);
        Died?.Invoke();
    }
}