using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    public GameObject map;
    public GameObject mapSelector;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveMap(GameObject mapSelector)
    {
        map = mapSelector;
    }

    public void loadMap()
    {
        Instantiate(map);
        DontDestroyOnLoad(map);
    }
    public void dodestroy()
    {
        Destroy(mapSelector);
    }
}
