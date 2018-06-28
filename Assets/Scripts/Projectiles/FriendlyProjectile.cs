using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour {

    public float damage = 5f;

    public GameObject shootingPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(!collision.CompareTag("Player") && !collision.CompareTag("Projectile"))
        {
            
            Target target = collision.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage, this.gameObject);
            }
            
            Destroy(this.gameObject);
        }
       
    }

    public void setShootingPlayer(GameObject shootingPlayer)
    {
        this.shootingPlayer = shootingPlayer;
    }

    public GameObject getShootingPlayer()
    {
        return this.shootingPlayer;
    }
    
}
