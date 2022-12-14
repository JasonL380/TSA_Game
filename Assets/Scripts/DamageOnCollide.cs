using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damageAmount = 1;
    public bool DestroyOnCollide = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.takeDamage(damageAmount);
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
            health.takeDamage(damageAmount);

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
