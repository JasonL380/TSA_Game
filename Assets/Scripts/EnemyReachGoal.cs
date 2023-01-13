/*
Mateo Ferdico 1/12/2023
Reacts when enemy object reaches a goal object and damages the players health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyReachGoal : MonoBehaviour
{
    PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal") == true)
        {
            player.Damage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal") == true)
        {
            player.Damage();
            Destroy(gameObject);
        }
    }
}
