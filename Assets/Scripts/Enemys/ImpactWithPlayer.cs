using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ImpactWithPlayer : MonoBehaviour {

    public float impactDamage = 1f;
    public float impactForce = 1000f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerTarget target = collision.collider.transform.GetComponent<PlayerTarget>();

            if(target != null)
            {
                target.TakeDamage(impactDamage);
                // pushing the player away from the asteroid
                collision.collider.transform.GetComponent<Rigidbody2D>().AddForce(calculateNormalizedCollisionVector(collision.collider.transform) * impactForce);
            }
        }   
    }

    private Vector2 calculateNormalizedCollisionVector(Transform colliderTransform)
    {
        Vector2 colliderVector = new Vector2(colliderTransform.position.x, colliderTransform.position.y);
        Vector2 ownVector = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 normalizedCollisionVector = (colliderVector - ownVector).normalized;
        return normalizedCollisionVector;

    }

    private void doSomethingOnSceneLoad()
    {
        SceneManager.sceneLo
    }
    

}
