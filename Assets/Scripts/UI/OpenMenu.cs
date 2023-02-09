using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject FirstSelected;
    public void enable()
    {
        MultiplayerEventSystem.current.SetSelectedGameObject(null);
        MultiplayerEventSystem.current.SetSelectedGameObject(FirstSelected);
    }
}
