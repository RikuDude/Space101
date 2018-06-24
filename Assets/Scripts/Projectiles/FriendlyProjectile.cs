using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour {

    public float damage = 5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if(!collision.CompareTag("Player") && !collision.CompareTag("Projectile"))
        {


            Target target = collision.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            
            Destroy(this.gameObject);
        }
       


    }


   


}
