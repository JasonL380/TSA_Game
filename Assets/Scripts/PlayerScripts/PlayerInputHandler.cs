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

    private void Start()
    {
        controls = new PlayerControls();
        player = gameObject; 
    }

    public void InitializePlayer(PlayerConfiguration config, int playerNum, LayerMask Layer)
    {
        playerConfig = config;
        PlayerNum = playerNum;
        player.layer = Layer;
    }   



}
