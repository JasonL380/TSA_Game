/*
Mateo Ferdico 1/17/23
Spawns enemies in waves
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class WaveSystem : MonoBehaviour
{

    public bool autoWaves = true;

    public Vector2[] player1SpawnPoints;

    public Vector2[] player2SpawnPoints;

    int waveCount = 0;

    public int timer;

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
        Instantiate(BasicEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveOneB()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[2], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[2], Quaternion.identity);
    }
    void WaveTwoA()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveTwoB()
    {
        Instantiate(FastEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[2], Quaternion.identity);

        Instantiate(FastEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[2], Quaternion.identity);
    }
    void WaveTwoC()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveThreeA()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveThreeB()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveFourA()
    {
        Instantiate(BasicEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(TankEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(BasicEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveFourB()
    {
        Instantiate(FastEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(FastEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveFiveA()
    {
        Instantiate(TankEnemy, player1SpawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[3], Quaternion.identity);

        Instantiate(TankEnemy, player2SpawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[3], Quaternion.identity);
    }
    void WaveFiveB()
    {
        Instantiate(FastEnemy, player1SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player1SpawnPoints[2], Quaternion.identity);
        Instantiate(TankEnemy, player1SpawnPoints[3], Quaternion.identity);
        Instantiate(FastEnemy, player1SpawnPoints[0], Quaternion.identity);

        Instantiate(FastEnemy, player2SpawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, player2SpawnPoints[2], Quaternion.identity);
        Instantiate(TankEnemy, player2SpawnPoints[3], Quaternion.identity);
        Instantiate(FastEnemy, player2SpawnPoints[0], Quaternion.identity);
    }
}
