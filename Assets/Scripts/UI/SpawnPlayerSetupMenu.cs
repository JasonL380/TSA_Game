using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetupMenuPrefab;
    public PlayerInput input;

    private InputSystemUIInputModule module = null;

    private void Awake()
    {
        var rootMenu = GameObject.Find("MainLayout");
        if (rootMenu != null)
        {
            var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
            module = menu.GetComponentInChildren<InputSystemUIInputModule>();
            input.uiInputModule = module;
            menu.GetComponent<PlayerSetupMenuController>().setPlayerIndex(input.playerIndex);
        }
        else
        {
            Debug.Log("MenuNotFound!");
        }
    }

    public IEnumerator WillResetModule()
    {
        yield return new WaitForSeconds(0.25f);
        StartCoroutine("ResetModule");
    }

    public IEnumerator ResetModule()
    {
        module.enabled = false;
        yield return new WaitForSeconds(0.25f);
        module.enabled = true;
    }
}
