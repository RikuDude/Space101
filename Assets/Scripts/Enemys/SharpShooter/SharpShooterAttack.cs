﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpShooterAttack : MonoBehaviour {

    private GameObject targetPlayer;

    public GameObject sharpShooterProjectile;

    public Transform playerBoundary;

    private float distanceTweak = 0.35f;

    private float timeUntilAquieringNextTarget = 3f;
    private float nextTimeToAquireNextTarget = 0f;

    public float fireRate = 1f;
    private float nextTimeToFire = 0f;

    void Start()
    {
        playerBoundary = GameObject.Find("PlayerBoundary").transform;
    }

    void Update()
    {

        if (Time.time >= nextTimeToAquireNextTarget)
        {
            aquireTargetPlayer();
            nextTimeToAquireNextTarget = Time.time + timeUntilAquieringNextTarget;
        }

        if (Time.time >= nextTimeToFire && isOnScreen())
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ShootAtTargetPlayer();

            //Debug.Log("Fires at target player!");
        }
    }


    private void aquireTargetPlayer()
    {

        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        if (allPlayers.Length > 0)
        {

            GameObject closestPlayer = allPlayers[0];

            foreach (GameObject player in allPlayers)
            {
                if (Vector2.Distance(this.transform.position, player.transform.position) < Vector2.Distance(this.transform.position, closestPlayer.transform.position))
                {
                    closestPlayer = player;
                }
            }

            targetPlayer = closestPlayer;
        }
    }

    private void ShootAtTargetPlayer()
    {
        if (targetPlayer != null)
        {
            Instantiate(sharpShooterProjectile, transform.position, rotateProjectileTowardsTarget(this.predictTargetPosition()));
        }

    }

    private Quaternion rotateProjectileTowardsTarget(Vector2 targetPosition)
    {

        Vector2 normalizedShootingDirection = targetPosition - new Vector2(this.transform.position.x, this.transform.position.y);

        normalizedShootingDirection.Normalize();

        float angle = Mathf.Atan2(normalizedShootingDirection.y, normalizedShootingDirection.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle + 270f);

    }

    private Vector2 predictTargetPosition()
    {
        Vector2 currentPositionOfTarget = new Vector2(targetPlayer.transform.position.x, targetPlayer.transform.position.y);
        Vector2 targetMovementDirection = targetPlayer.transform.GetComponent<PlayerController>().getShipMovement();

        Vector2 predictedPosition = currentPositionOfTarget + targetMovementDirection * Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), currentPositionOfTarget) * distanceTweak;

        return predictedPosition;
    }

    private bool isOnScreen()
    {
        if (this.transform.position.y < playerBoundary.GetChild(0).transform.position.y && this.transform.position.y > playerBoundary.GetChild(1).transform.position.y && this.transform.position.x > playerBoundary.GetChild(2).transform.position.x && this.transform.position.x < playerBoundary.GetChild(3).transform.position.x)
        {
            return true;
        }
        return false;
    }

    public GameObject getTargetPlayer()
    {
        return this.targetPlayer;
    }

    
}
