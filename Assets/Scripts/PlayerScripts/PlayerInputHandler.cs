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
    //private SpriteRenderer playerMesh;

    private PlayerControls controls;

    public int PlayerNum;

    public GameObject player;

    public LayerMask LayerMask1;
    public LayerMask LayerMask2;

    private void Start()
    {
        controls = new PlayerControls();
        player = gameObject; 
    }

    public void InitializePlayer(PlayerConfiguration config, int playerNum, LayerMask layer )
    {
        playerConfig = config;
        PlayerNum = playerNum;
        player.layer = layer;
    }   



}
