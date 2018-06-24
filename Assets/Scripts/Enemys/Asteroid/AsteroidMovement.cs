using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    Rigidbody2D myRigidbody;

    //public float speed = 10;

    public Transform targetBoundaryHolder;

	// Use this for initialization
	void Start () {
        targetBoundaryHolder = GameObject.Find("TargetBoundary").transform;

        myRigidbody = this.GetComponent<Rigidbody2D>();
        Vector2 targetPosition = new Vector2(Random.Range( targetBoundaryHolder.GetChild(1).position.y, targetBoundaryHolder.GetChild(0).position.y), Random.Range(targetBoundaryHolder.GetChild(2).position.x, targetBoundaryHolder.GetChild(3).position.x));

        Vector2 forceDirection = targetPosition - new Vector2(this.transform.position.x, this.transform.position.y);

        forceDirection.Normalize();

        forceDirection = forceDirection * Random.Range(5000f, 7000f);

        myRigidbody.AddForce(forceDirection);
        myRigidbody.AddTorque(Random.Range(-2000f, 2000f));
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
