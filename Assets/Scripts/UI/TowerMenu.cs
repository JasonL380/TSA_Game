using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TowerMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OpenButton;
    public GameObject CloseMenues;
    public GameObject OpenMenues;
    public Utils.PlayerScripts.Cursor cursor;

    public bool IsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //Menu = GetComponent<GameObject>();
        Menu.SetActive(false);
        IsOpen = false;
        //cursor = GetComponent<Utils.PlayerScripts.Cursor>();
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
            OpenMenu(OpenButton);
        }
    }
    void OpenMenu(GameObject OpenButton)
    {
        cursor.movementEnabled = false;
        Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OpenButton);
        OpenMenues.SetActive(true);
        CloseMenues.SetActive(false);
        IsOpen = true;
    }
    void CloseMenu()
    {
        cursor.movementEnabled = true;
        Menu.SetActive(false);
        IsOpen = false;
    }
}
