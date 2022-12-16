using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitter : MonoBehaviour
{
    public GameObject splitChild;

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null)
        {
            Instantiate(splitChild, transform.position, transform.rotation);
            Instantiate(splitChild, transform.position, transform.rotation);
        }
    }
}
