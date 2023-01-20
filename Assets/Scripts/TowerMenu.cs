using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Cursor;

    public bool IsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //Menu = GetComponent<GameObject>();
        Menu.SetActive(false);
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOpenTowerMenu()
    {
        if(IsOpen)
        {
            CloseMenu();
        }
        else if(IsOpen == false)
        {
            OpenMenu();
        }
    }
    void OpenMenu()
    {
        Cursor.SetActive(false);
        Menu.SetActive(true);
        IsOpen = true;
    }
    void CloseMenu()
    {
        Cursor.SetActive(true);
        Menu.SetActive(false);
        IsOpen = false;
    }
}
