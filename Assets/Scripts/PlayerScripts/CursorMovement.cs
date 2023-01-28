using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorMovement : MonoBehaviour
{
    Vector2 positionValue;
    public bool isGamePad;
    public GameObject player;
    public Rigidbody2D rb2d;
    public new Camera camera;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       // if (Gamepad.current != null)
       // {
        //    rb2d.velocity = positionValue * speed;
        //}
    }

    public void OnCursor(InputAction.CallbackContext value)
    {
            positionValue = value.ReadValue<Vector2>();
    }

    public void OnGamePadCursor(InputAction.CallbackContext value)
    {
        positionValue = value.ReadValue<Vector2>();
        rb2d.velocity = positionValue * speed;
    }

    void OnClick()
    {
        
    }
}
