using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpShooterMovement : MonoBehaviour {

    public float sharpShooterSpeed = 1f;

    public Transform targetBoundaryHolder;

    private Vector2 movementDirection;

    Vector2 targetPosition;

    // Use this for initialization
    void Start()
    {
        targetBoundaryHolder = GameObject.Find("TargetBoundary").transform;

        targetPosition = new Vector2(Random.Range(targetBoundaryHolder.GetChild(2).position.x, targetBoundaryHolder.GetChild(3).position.x), Random.Range(targetBoundaryHolder.GetChild(0).position.y, targetBoundaryHolder.GetChild(1).position.y));

        movementDirection = targetPosition - new Vector2(this.transform.position.x, this.transform.position.y);

        movementDirection.Normalize();
        turnToTargetPlayer(this.transform.GetComponent<SharpShooterAttack>().getTargetPlayer());


    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), targetPosition) > 0.1f)
        {
            transform.Translate(movementDirection.x * Time.deltaTime * sharpShooterSpeed, movementDirection.y * Time.deltaTime * sharpShooterSpeed, 0, Space.World);
        }

        turnToTargetPlayer(this.transform.GetComponent<SharpShooterAttack>().getTargetPlayer());
    }



    private void turnToTargetPlayer(GameObject targetPlayer)
    {
        if(targetPlayer != null)
        {
            Vector2 lookingDirection = (new Vector2(targetPlayer.transform.position.x, targetPlayer.transform.position.y) - new Vector2(this.transform.position.x, this.transform.position.y));
            //transform.rotation = Quaternion.LookRotation(lookingDirection, Vector3.up);

            float angle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;

            //float angle = Mathf.Atan2(targetPlayer.transform.position.y, targetPlayer.transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 270);
        }
    }

}
