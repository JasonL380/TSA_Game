using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerConfiguration> playerConfigs;
    [SerializeField]
    private int MaxPlayers = 2;

    public PlayerInputManager playerInputManager;
    static public bool GameStarted = false;

    public string SceneChangeName;
    

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
        
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("PPlayer joined " + pi.playerIndex); 
        pi.transform.SetParent(transform);

        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
       // playerConfigs[index].playerMaterial = color;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene(SceneChangeName);
        }
    }
}

public class PlayerConfiguration : MonoBehaviour
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    [SerializeField]
    public PlayerInput Input { get; set; }
    [SerializeField]
    public int PlayerIndex { get; set; }
    public bool isReady { get; set; }
    //public Material playerMaterial { get; set; }
}