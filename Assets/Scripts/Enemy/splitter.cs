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
            Instantiate(splitChild, transform.position, transform.rotation);
            Instantiate(splitChild, transform.position, transform.rotation);
            hpScript.currentHealth = 0;
        }
    }
}
