using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject playerBullet;
    public float bulletSpeed;
    public float fireRate = 5f;

    private float nextTimeToFire = 0f;


    public float playerSpeed;
    protected Rigidbody2D myBody;
    protected CircleCollider2D myCollider;

    private float score = 0f;
    private Text scoreBoard;


    protected float rx = 0;
    protected float ry = 0;

    public Transform BoundaryHolder;

    Boundary playerBoundary;

    // Use this for initialization
    void Start()
    {
        
        myBody = this.GetComponent<Rigidbody2D>();
        myCollider = this.GetComponent<CircleCollider2D>();

        float actualRadiusOfSpaceship = myCollider.radius * 0.2209217f;

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y - actualRadiusOfSpaceship, BoundaryHolder.GetChild(1).position.y + actualRadiusOfSpaceship, BoundaryHolder.GetChild(2).position.x + actualRadiusOfSpaceship, BoundaryHolder.GetChild(3).position.x - actualRadiusOfSpaceship);

        this.scoreBoard = GameObject.Find("Player1HUD").transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        this.updateScoreBoard();

    }

   

    // Update is called once per frame
    void Update()
    {

        playerBullet.GetComponent<PlayerBullet>().setSpeed(speed: bulletSpeed);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * playerSpeed, y * Time.deltaTime * playerSpeed, 0, Space.World);

        
        if (Input.GetAxis("R1") == 1 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shootBullet();
        }


        Vector2 clampedPosition = this.transform.position;

        clampedPosition.x = Mathf.Clamp(transform.position.x, playerBoundary.left, playerBoundary.right);
        clampedPosition.y = Mathf.Clamp(transform.position.y, playerBoundary.down, playerBoundary.up);

        transform.position = clampedPosition;



        if ((Input.GetAxisRaw("Right_Horizontal") > 0.12f || Input.GetAxisRaw("Right_Horizontal") < -0.12f) || (Input.GetAxisRaw("Right_Vertical") > 0.12f || Input.GetAxisRaw("Right_Vertical") < -0.12f) )
        {
            rx = Input.GetAxisRaw("Right_Horizontal");
            ry = Input.GetAxisRaw("Right_Vertical");
        }    


        var input = new Vector2(rx, ry);

        // Debugging right stick inputs
        //Debug.Log("Right Horizontal:" + Input.GetAxis("Right_Horizontal"));
        //Debug.Log("Right Vertical:" + Input.GetAxis("Right_Vertical"));

        //Debug.Log("Left Horizontal:" + Input.GetAxis("Horizontal"));
        //Debug.Log("Left Vertical:" + Input.GetAxis("Vertical"));


        //Debug.Log("R1: " + Input.GetAxis("R1"));


        var angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }

    public void shootBullet()
    {
        GameObject bullet = Instantiate(playerBullet, transform.position, transform.rotation);
        bullet.transform.GetComponent<FriendlyProjectile>().setShootingPlayer(this.gameObject);
    }


    public void addScore(float amount)
    {
        this.score += amount;
    }

    public float getScore()
    {
        return this.score;
    }

    public void updateScoreBoard()
    {
        this.scoreBoard.text = "" + this.score;
    }

    struct Boundary
    {
        public float up, down, left, right;

        public Boundary(float up, float down, float left, float right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }
    }

    


}
