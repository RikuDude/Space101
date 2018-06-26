using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneProjectile : MonoBehaviour {

    public float damage = 5f;

    public float speed;
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
        
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Projectile"))
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
