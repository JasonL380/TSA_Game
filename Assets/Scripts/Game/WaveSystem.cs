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

    [Tooltip("Set # of waves, must be at least 5")]

    public int howManyWaves;

    public Vector2[] player1SpawnPoints;
    public Vector2[] player2SpawnPoints;

    public Vector2[] player1EndPoints;
    public Vector2[] player2EndPoints;

    private int prevSpawn;

    public int waveCount;

    public GameObject BasicEnemy;
    public GameObject FastEnemy;
    public GameObject DuplicateEnemy;
    public GameObject TankEnemy;

    // Start is called before the first frame update
    void Start()
    {
        if (autoWaves)
        {
            Invoke("WaveOneA", 10);
            Invoke("WaveOneB", 13);

            Invoke("WaveTwoA", 18);
            Invoke("WaveTwoB", 21);
            Invoke("WaveTwoC", 24);

            Invoke("WaveThreeA", 30);
            Invoke("WaveThreeB", 33);

            Invoke("WaveFourA", 40);
            Invoke("WaveFourB", 44);

            Invoke("WaveFiveA", 50);
            Invoke("WaveFiveB", 54);

            for (int i = 0; i < howManyWaves - 5; i++)
            {
                Invoke("RandomWave", 60 + (i * 8));
                Invoke("RandomWave", 63 + (i * 8));
            }

        }
    }

    public void spawnEnemyButton(GameObject enemy)
    {
        spawnEnemy(enemy);
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
        ++waveCount;
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
        ++waveCount;
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
        ++waveCount;
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
        ++waveCount;
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
        ++waveCount;
    }

    void RandomWave()
    {
        for (int i = 0; i < rand.Next(waveCount) + 10; i++)
        {
            int enemyType = rand.Next(100);
            if (enemyType >= 0 && enemyType < 49) //50% chance to spawn basicenemy
            {
                spawnEnemy(BasicEnemy);
            }
            else if (enemyType < 69) //20% chance to spawn fastenemy
            {
                spawnEnemy(FastEnemy);
            }
            else if (enemyType < 89) //20% chance to spawn duplicateenemy
            {
                spawnEnemy(DuplicateEnemy);
            }
            else //10% chance to spawn tankenemy
            {
                spawnEnemy(TankEnemy);
            }
        }
        ++waveCount;
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
        //Debug.Log(r);
        while(r == prevSpawn)
        {
            r = rand.Next(player1SpawnPoints.Length);
        }
        prevSpawn = r;
        return r;
    }
}
