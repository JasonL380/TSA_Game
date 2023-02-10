/*
 * General script, not just for health
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
        [Min(0)]
    public int currentHealth = 3;
        [Min(1)]
    [SerializeField]
    public int maxHealth = 3;
    public bool destroyAtZero = true;
    public Slider HealthBarSlider;
    public int damageTaken;
    public int genSouls;
    public int specSouls;
    public int money;

    public GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    
    /// <summary>
    /// Take a specified amount of damage from a specified turret
    /// </summary>
    /// <param name="damage">The amount of damage to do</param>
    /// <param name="turret">The turret that damage is being taken from</param>
    public void takeDamage(int damage, Turret turret) //deals damage based on getting a collision from a bullet
    {
        currentHealth -= damage; //takes damage from a value
        if (currentHealth <= 0)
        {
            //add souls/money
            if (turret != null)
            {
                turret.moneyManager.AddMoney(money);
            }
            else
            {
                print("turret is null");
            }
            
            //run death things here
            DeathEffects deathEffects = GetComponent<DeathEffects>();
            if (deathEffects != null)
            {
                deathEffects.deathEvent.Invoke();
            }
            if (destroyAtZero) 
            {
                deathEffects = GetComponent<DeathEffects>();
                if (deathEffects != null)
                {
                    deathEffects.deathEvent.Invoke();
                }
                Destroy(gameObject);
            }
        }
    }
}
