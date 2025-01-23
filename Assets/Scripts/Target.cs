using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
            Destroy(gameObject);
    }
    
}
