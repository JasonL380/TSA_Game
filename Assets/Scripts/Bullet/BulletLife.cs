/*
Mateo Ferdico 12/15/22
Destroys the object after a specific time set by user
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{

    [Tooltip("How long the bullet lives:")]
    public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
