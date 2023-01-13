/*
Mateo Ferdico 1/12/2023
Deals with player health and switches to game over scene on death
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health = 3;
    public int maxHealth = 3;

    public string gameOverScene = "gameOverScene";

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage()
    {
        health -= 1;
        if (health <= 0)
        {
            GameOverScene();
        }
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
