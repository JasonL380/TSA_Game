/*
Mateo Ferdico 1/17/23
Spawns enemies in waves
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    System.Random rand = new System.Random();
    
    public bool autoWaves = true;

    public Vector2[] player1SpawnPoints;
    public Vector2[] player2SpawnPoints;

    public Vector2[] player1EndPoints;
    public Vector2[] player2EndPoints;

    private int spawn;
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

    public void spawnEnemy(GameObject enemy)
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
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveOneB()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveTwoA()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);


        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveTwoB()
    {
        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveTwoC()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);        
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveThreeA()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }

    void WaveThreeB()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(TankEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveFourA()
    {
        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(TankEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(TankEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(BasicEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveFourB()
    {
        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(DuplicateEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(DuplicateEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveFiveA()
    {
        randNum();
        Instantiate(TankEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(DuplicateEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(DuplicateEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[spawn], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[spawn], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[spawn], Quaternion.identity);
    }
    void WaveFiveB()
    {
        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[1], Quaternion.identity);

        randNum();
        Instantiate(DuplicateEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[2], Quaternion.identity);

        randNum();
        Instantiate(TankEnemy, player1SpawnPoints[3], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[3], Quaternion.identity);

        randNum();
        Instantiate(FastEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[0], Quaternion.identity);
    }

    void randNum()
    {
        int r = rand.Next(player1SpawnPoints.Length);
        Debug.Log(r);
        while(r == prevSpawn)
        {
            r = rand.Next(player1SpawnPoints.Length);
        }
        spawn = r;
        prevSpawn = spawn;
    }
}
