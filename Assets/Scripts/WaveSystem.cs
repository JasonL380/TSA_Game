/*
Mateo Ferdico 1/17/23
Spawns enemies in waves
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    System.Random rand = new System.Random();
    
    public bool autoWaves = true;

    public Vector2[] player1SpawnPoints;
    public Vector2[] player2SpawnPoints;

    public Vector2[] player1EndPoints;
    public Vector2[] player2EndPoints;

    private int prevSpawn;

    public GameObject BasicEnemy;
    public GameObject FastEnemy;
    public GameObject DuplicateEnemy;
    public GameObject TankEnemy;
    // Start is called before the first frame update
    void Start()
    {
        if (autoWaves)
        {
            Invoke("WaveOneA", 0);
            Invoke("WaveOneB", 2);

            Invoke("WaveTwoA", 7);
            Invoke("WaveTwoB", 9);
            Invoke("WaveTwoC", 11);

            Invoke("WaveThreeA", 16);
            Invoke("WaveThreeB", 19);

            Invoke("WaveFourA", 24);
            Invoke("WaveFourB", 27);

            Invoke("WaveFiveA", 32);
            Invoke("WaveFiveB", 36);
        }
    }

    public void spawnEnemyButton(GameObject enemy)
    {
        Instantiate(enemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(enemy, player2SpawnPoints[1], Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void WaveOneA()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveOneB()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveTwoA()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveTwoB()
    {
        spawnEnemy(FastEnemy);
        spawnEnemy(FastEnemy);
    }
    void WaveTwoC()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveThreeA()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(FastEnemy);
        spawnEnemy(FastEnemy);
        spawnEnemy(BasicEnemy);
    }

    void WaveThreeB()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(TankEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveFourA()
    {
        spawnEnemy(BasicEnemy);
        spawnEnemy(TankEnemy);
        spawnEnemy(TankEnemy);
        spawnEnemy(BasicEnemy);
    }
    void WaveFourB()
    {
        spawnEnemy(FastEnemy);
        spawnEnemy(DuplicateEnemy);
        spawnEnemy(DuplicateEnemy);
        spawnEnemy(FastEnemy);
    }
    void WaveFiveA()
    {
        spawnEnemy(TankEnemy);
        spawnEnemy(DuplicateEnemy);
        spawnEnemy(DuplicateEnemy);
        spawnEnemy(FastEnemy);
    }
    void WaveFiveB()
    {
        spawnEnemy(FastEnemy);
        spawnEnemy(DuplicateEnemy);
        spawnEnemy(TankEnemy);
        spawnEnemy(FastEnemy);
    }

    void spawnEnemy(GameObject enemy)
    {
        int spawn = randNum();
        GameObject newEnemy = Instantiate(enemy, player1SpawnPoints[spawn], Quaternion.identity);
        Pathfinder pathfinder = newEnemy.GetComponent<Pathfinder>();
        pathfinder.waypoints[0] = player1EndPoints[spawn];

        newEnemy = Instantiate(enemy, player2SpawnPoints[spawn], Quaternion.identity);
        pathfinder = newEnemy.GetComponent<Pathfinder>();
        pathfinder.waypoints[0] = player2EndPoints[spawn];
    }

    int randNum()
    {
        int r = rand.Next(player1SpawnPoints.Length);
        Debug.Log(r);
        while(r == prevSpawn)
        {
            r = rand.Next(player1SpawnPoints.Length);
        }
        prevSpawn = r;
        return r;
    }
}
