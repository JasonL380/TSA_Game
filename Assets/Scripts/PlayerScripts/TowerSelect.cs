using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour
{

    public GameObject TowerSelected;

    public int TowerCost;

    SelectManager selectManager;
    // Start is called before the first frame update
    void Start()
    {
        selectManager = GameObject.FindObjectOfType<SelectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoughtTower()
    {
        //TODO add cost here
        selectManager.enablePurchase(TowerSelected);
        Debug.Log("tower Bought!");
    }
}
