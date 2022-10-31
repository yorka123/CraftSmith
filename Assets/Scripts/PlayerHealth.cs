using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public HealthBar healthBar;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(CurrentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }

}
