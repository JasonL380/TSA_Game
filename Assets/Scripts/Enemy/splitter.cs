using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class splitter : MonoBehaviour
{
    public GameObject splitChild;
    public Health hpScript;

    private void Start()
    {
        hpScript = gameObject.GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if(hpScript.currentHealth == 1)
        {
            Vector2 target = GetComponent<Pathfinder>().waypoints[0];
            GameObject newEnemy = Instantiate(splitChild, transform.position, transform.rotation);
            Pathfinder pathfinder = newEnemy.GetComponent<Pathfinder>();
            pathfinder.waypoints[0] = target;
            
            newEnemy = Instantiate(splitChild, transform.position, transform.rotation);
            pathfinder = newEnemy.GetComponent<Pathfinder>();
            pathfinder.waypoints[0] = target;
            hpScript.currentHealth = 0;
        }
    }
}
