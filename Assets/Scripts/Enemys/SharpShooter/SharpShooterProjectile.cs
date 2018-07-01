using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpShooterProjectile : MonoBehaviour {

    public float damage = 10f;

    public float speed = 10f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = transform.TransformDirection(new Vector2(0f, 1f) * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Projectile") && !collision.CompareTag("Powerup"))
        {

            PlayerTarget target = collision.transform.GetComponent<PlayerTarget>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }

    }
}
