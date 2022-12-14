/*
 * zak baydass
 * 10/28/2022
 * ths script doesnt get used, health system was reworked.
 */

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

    [SerializeField]
    private Transform[] PlayerSpawns;

    public GameManager manager;

    public int playerNum;
    int PlayerIndex;
    private void Start()
    {
        PlayerIndex = playerNum;
        manager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        HealthBarSlider.value = currentHealth; //sets health bar slider to the current health always
        HealthBarSlider.maxValue = maxHealth;

    }
    public void takeDamage(int damage) //deals damage based on getting a collision from a bullet
        {
            currentHealth -= damage; //takes damage from a value
            if (currentHealth <= 0)
            {
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
    public void Respawn()
    {
        //gameObject.transform.position = (LevelInitializer.PlayerSpawns[1].position);
        currentHealth = maxHealth;
        HealthBarSlider.value = currentHealth;
        transform.position = (PlayerSpawns[Random.Range(0, PlayerSpawns.Length)].position);    
        manager.GetComponent<GameManager>();
        manager.LosePoint(playerNum);
    }
}
