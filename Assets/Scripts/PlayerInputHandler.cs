using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    [SerializeField]
    private SpriteRenderer playerMesh;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;

    }   



}
