/*
 * zak baydass
 * 10/28/2022
 * this is what allows the music in the game to play during the scene transitions
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicobj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
