using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    Vector2 positionValue;
    public bool isGamePad;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = positionValue;
    }

   public void OnCursor(InputAction.CallbackContext value)
    {

        positionValue = value.ReadValue<Vector2>();
    }

    void OnClick()
    {

    }
}
