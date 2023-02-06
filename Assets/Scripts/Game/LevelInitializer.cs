using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] PlayerSpawns;

    [SerializeField]
    private GameObject playerPrefab;
    public int PlayerNum = 0;

    public int MaxPlayer = 2;

    public GameObject[] PlayerList = new GameObject[2];

   // LayerMask layerMask;
    
    // Start is called before the first frame update
    void Awake()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            PlayerNum++;
            //layerMask = PlayerSpawns[i].gameObject.layer;
            var Pplayer = Instantiate(playerPrefab, PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
            Pplayer.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i], PlayerNum , PlayerSpawns[i].gameObject.layer);
            Pplayer.GetComponentInChildren<Utils.PlayerScripts.Cursor>().side = i;
            PlayerList[i] = Pplayer;
        }
        
    }

}
