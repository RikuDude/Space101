using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public float waveDifficulty = 2;
    public float timeBetweenWaves = 30;

    private float nextTimeToSpawnWave = 0;
    public Transform spawnBoundary;

    public List<GameObject> listOfAllEnemyTypes;

    private Text nextWaveClockBoard;


	// Use this for initialization
	void Start () {
        nextWaveClockBoard = GameObject.Find("Clock").transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Pad"))
        {
            nextTimeToSpawnWave = Time.time;
        }

        if(Time.time >= nextTimeToSpawnWave)
        {
            SpawnWave();
            nextTimeToSpawnWave = Time.time + timeBetweenWaves;
        }

	}


    private void SpawnWave()
    {

        for (int i = 0; i < waveDifficulty; i++)
        {
            Vector2 randomizedSpawnPoint = generateRandomizedSpawnPoint();
            Instantiate(this.listOfAllEnemyTypes[Random.Range(0, listOfAllEnemyTypes.Count)], new Vector3(randomizedSpawnPoint.x, randomizedSpawnPoint.y, 0), new Quaternion(0f, 0f, 0f, 0f));
        }

        waveDifficulty = waveDifficulty + 2;
        
    }


    private Vector2 generateRandomizedSpawnPoint()
    {
        Vector2 randomizedSpawnPoint = new Vector2();

        switch (Random.Range(1, 4))
        {
            case 1:
                randomizedSpawnPoint.Set(Random.Range(spawnBoundary.transform.GetChild(2).transform.position.x, spawnBoundary.transform.GetChild(3).transform.position.x), spawnBoundary.transform.GetChild(0).transform.position.y);
                break;
            case 2:
                randomizedSpawnPoint.Set(Random.Range(spawnBoundary.transform.GetChild(2).transform.position.x, spawnBoundary.transform.GetChild(3).transform.position.x), spawnBoundary.transform.GetChild(1).transform.position.y);
                break;
            case 3:
                randomizedSpawnPoint.Set(spawnBoundary.transform.GetChild(2).transform.position.x, Random.Range(spawnBoundary.transform.GetChild(1).transform.position.y, spawnBoundary.transform.GetChild(0).transform.position.y));
                break;
            case 4:
                randomizedSpawnPoint.Set(spawnBoundary.transform.GetChild(3).transform.position.x, Random.Range(spawnBoundary.transform.GetChild(1).transform.position.y, spawnBoundary.transform.GetChild(0).transform.position.y));
                break;
            default:

                break;
        }
        return randomizedSpawnPoint;
    }

    private void updateNextWaveClock()
    {

    }
}
