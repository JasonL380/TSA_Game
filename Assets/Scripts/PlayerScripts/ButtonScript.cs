using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{   
    public Button buttn;

    public Vector2 position;
    GameObject tower;
    GameObject Grid;

    TurretGrid turretGrid;

    SelectManager selectManager;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        buttn = GetComponent<Button>();
        turretGrid = GameObject.FindObjectOfType<TurretGrid>();
        position = transform.position;
        selectManager = GameObject.FindObjectOfType<SelectManager>();
    }

    void OnClick()
    {
        towerPurchase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetTower()
    {
        //TODO add confirm button before selecting
        print(tower + " " + position + " " + layer);
        //turretGrid.PlaceObjectAtPosition(tower, position, layer);
        Debug.Log("tower placed at" + position.x + "by" + position.y);
    }

    public void towerPurchase()
    {
        if(selectManager.purchaseState())
        {
            tower = selectManager.disablePurchase();
            SetTower();
        }
    }
}
