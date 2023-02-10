using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damageAmount = 1;
    public bool DestroyOnCollide = true;
    public float damageDelay = 0f;
    private float damageTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if(damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null && damageTimer == 0f)
        {
            health.takeDamage(damageAmount, null);
            damageTimer = damageDelay;
        }
        if (DestroyOnCollide)
        {
            DeathEffects deathEffects = GetComponent<DeathEffects>();
            if (deathEffects != null)
            {
                deathEffects.deathEvent.Invoke();
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.takeDamage(damageAmount, null);

        }
        if (DestroyOnCollide)
        {
            DeathEffects deathEffects = GetComponent<DeathEffects>();
            if (deathEffects != null)
            {
                deathEffects.deathEvent.Invoke();
            }
            Destroy(gameObject);
        }
    }

}
