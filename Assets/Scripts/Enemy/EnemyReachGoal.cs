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
    PlayerHealth goal1;
    PlayerHealth goal2;
    // Start is called before the first frame update
    void Start()
    {
        goal1 = GameObject.FindGameObjectWithTag("Goal1").GetComponent<PlayerHealth>();
        goal2 = GameObject.FindGameObjectWithTag("Goal2").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal1") == true)
        {
            goal1.Damage();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Goal2") == true)
        {
            goal2.Damage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal1") == true)
        {
            goal1.Damage();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Goal2") == true)
        {
            goal2.Damage();
            Destroy(gameObject);
        }
    }
}
