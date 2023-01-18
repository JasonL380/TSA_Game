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

    public Vector2[] spawnPoints;
    
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
        Instantiate(enemy, spawnPoints[1], Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void WaveOneA()
    {
        Instantiate(BasicEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveOneB()
    {
        Instantiate(BasicEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[2], Quaternion.identity);
    }
    void WaveTwoA()
    {
        Instantiate(BasicEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveTwoB()
    {
        Instantiate(FastEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[2], Quaternion.identity);
    }
    void WaveTwoC()
    {
        Instantiate(BasicEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveThreeA()
    {
        Instantiate(BasicEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveThreeB()
    {
        Instantiate(BasicEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveFourA()
    {
        Instantiate(BasicEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(TankEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(TankEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(BasicEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveFourB()
    {
        Instantiate(FastEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveFiveA()
    {
        Instantiate(TankEnemy, spawnPoints[0], Quaternion.identity);
        Instantiate(DuplicateEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[3], Quaternion.identity);
    }
    void WaveFiveB()
    {
        Instantiate(FastEnemy, spawnPoints[1], Quaternion.identity);
        Instantiate(DuplicateEnemy, spawnPoints[2], Quaternion.identity);
        Instantiate(TankEnemy, spawnPoints[3], Quaternion.identity);
        Instantiate(FastEnemy, spawnPoints[0], Quaternion.identity);
    }
}
