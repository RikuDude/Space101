using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour {

    public float droneSpeed = 10f;

    public Transform targetBoundaryHolder;

    private Vector2 movementDirection;

    // Use this for initialization
    void Start () {
        targetBoundaryHolder = GameObject.Find("TargetBoundary").transform;

        Vector2 targetPosition = new Vector2(Random.Range(targetBoundaryHolder.GetChild(1).position.y, targetBoundaryHolder.GetChild(0).position.y), Random.Range(targetBoundaryHolder.GetChild(2).position.x, targetBoundaryHolder.GetChild(3).position.x));

        movementDirection = targetPosition - new Vector2(this.transform.position.x, this.transform.position.y);

        movementDirection.Normalize();

        turnToMovementDirection(movementDirection);
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(movementDirection.x * Time.deltaTime * droneSpeed, movementDirection.y * Time.deltaTime * droneSpeed, 0, Space.World);
        
    }



    private void turnToMovementDirection(Vector2 movementDirection)
    {

        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 270f);

    }

}
