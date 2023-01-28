using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLoader : MonoBehaviour
{
    MapSelector mapselector;
    
    private void Awake()
    {
        mapselector = FindObjectOfType<MapSelector>();
        mapselector.loadMap();
        mapselector.dodestroy();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
