// Name: Jason Leech
// Date: 12/14/2022
// Desc: T

using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Turret : MonoBehaviour
{
    [Tooltip("The layers that this turret should shoot at")]
    public LayerMask targetLayers;
    [Tooltip("The bullet prefab")]
    public GameObject bullet;

    [Tooltip("The speed that the bullet moves at")]
    public float bulletSpeed;
    [Tooltip("Event that runs whenever a bullet fires")]
    public UnityEvent fireEvent;
    [Tooltip("The time in seconds between firing")]
    public float fireRate;
    [Tooltip("The range of this turret")] 
    public float range;

    private GameObject currentTarget;
    private float currentFireTime;

    private void Start()
    {
        currentFireTime = 0;
    }

    private void FixedUpdate()
    {
        currentFireTime -= Time.deltaTime;
        //print(Time.deltaTime + ", " + currentFireTime);
        if (currentFireTime <= 0)
        {
            //print("firing");
            currentFireTime = fireRate;
            if (currentTarget != null)
            {
                //get a vector to the target
                Vector3 toTarget = currentTarget.transform.position - transform.position;

                //check if the target has gone out of range
                if (toTarget.magnitude > range)
                {
                    currentTarget = null;
                }
                else
                {
                    fireEvent.Invoke();
                    Quaternion angle = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(toTarget.y, toTarget.x));
                    //rotate towards the target
                    transform.rotation = angle;
                    
                    //fire at the target
                    GameObject bullet2 = GameObject.Instantiate(bullet, transform.position, angle);

                    Rigidbody2D bulletRb2d = bullet2.GetComponent<Rigidbody2D>();

                    bulletRb2d.velocity = toTarget * bulletSpeed;
                }
            }
            else
            {
                //there is no current target, attempt to find a new one
                Collider2D target = Physics2D.OverlapCircle(transform.position, range, targetLayers);
                if (target != null)
                {
                    currentTarget = target.gameObject;
                }
            }
        }
    }
}
