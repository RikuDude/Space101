using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour {

    private GameObject targetPlayer;

    private float timeUntilAquieringNextTarget = 5;

    public float fireRate = 5f;

    void Start () {
		
	}

	void Update () {
		
	}


    private void aquireTargetPlayer()
    {

        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        if (allPlayers.Length > 0) {

            GameObject closestPlayer = allPlayers[0];

            foreach (GameObject player in allPlayers)
            {
                if(Vector2.Distance(this.transform.position, player.transform.position) < Vector2.Distance(this.transform.position, closestPlayer.transform.position))
                {
                    closestPlayer = player;
                }                
            }

            targetPlayer = closestPlayer;
        }
    }

    private void ShootAtTargetPlayer()
    {

    }

}
