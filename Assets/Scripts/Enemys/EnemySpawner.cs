using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    private int gameDifficulty;

    public float waveDifficulty = 2;
    public float timeBetweenWaves = 30;

    private float nextTimeToSpawnWave = 0;
    public Transform spawnBoundary;

    public List<GameObject> listOfAllEnemyTypes;

    private Text nextWaveClockBoard;


	// Use this for initialization
	void Start () {
        nextWaveClockBoard = GameObject.Find("Clock").transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
        gameDifficulty = User.Difficulty;

        switch (gameDifficulty)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            default:
                break;
        }
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

        updateNextWaveClock();

	}


    private void SpawnWave()
    {

        for (int i = (int)waveDifficulty; i > 0;)
        {
            Vector2 randomizedSpawnPoint = generateRandomizedSpawnPoint();

            GameObject spawnedEnemy;

            if (i >= 5)
            {
                spawnedEnemy = this.listOfAllEnemyTypes[Random.Range(0, listOfAllEnemyTypes.Count)];
            } else if (i >= 3)
            {
                spawnedEnemy = this.listOfAllEnemyTypes[Random.Range(0, listOfAllEnemyTypes.Count) - 1];
            } else
            {
                spawnedEnemy = this.listOfAllEnemyTypes[0];
            }
            
            Instantiate(spawnedEnemy, new Vector3(randomizedSpawnPoint.x, randomizedSpawnPoint.y, 0), new Quaternion(0f, 0f, 0f, 0f));

            i -= spawnedEnemy.transform.GetComponent<Difficulty>().getDifficulty();
        }

        if(gameDifficulty == 0)
        {
            waveDifficulty = waveDifficulty + 2;
        }
        else if (gameDifficulty == 1)
        {
            waveDifficulty = waveDifficulty * 2;
        }
        else if (gameDifficulty == 2)
        {
            waveDifficulty = waveDifficulty * waveDifficulty;
        }
        else
        {
            waveDifficulty = waveDifficulty + 2;
        }
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
        nextWaveClockBoard.text = "NextWave: " + ((int)nextTimeToSpawnWave - (int)(Time.time % 6000));
    }
}
