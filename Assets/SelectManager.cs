using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private bool purchaseEnabled = false;
    private GameObject purchasedTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void enablePurchase(GameObject tower)
    {
        purchaseEnabled = true;
        purchasedTower = tower;
        print(purchasedTower);
    }

    public GameObject disablePurchase()
    {
        purchaseEnabled = false;
        return purchasedTower;
    }

    public bool purchaseState()
    {
        return purchaseEnabled;
    }
}
