using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;
    Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = transform.TransformDirection(new Vector2(0f, 1f) * speed);
	}


    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
