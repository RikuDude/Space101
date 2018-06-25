using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneProjectile : MonoBehaviour {

    public float damage = 5f;


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
