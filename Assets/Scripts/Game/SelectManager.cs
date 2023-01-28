using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private bool purchaseEnabled = false;
    private GameObject purchasedTower;
    private int towerCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void enablePurchase(GameObject tower, int cost)
    {
        purchaseEnabled = true;
        purchasedTower = tower;
        towerCost = cost;
        print(purchasedTower);
    }

    public GameObject purchaseObject()
    {
        return purchasedTower;
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
