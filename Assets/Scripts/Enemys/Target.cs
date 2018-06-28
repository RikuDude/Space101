using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

    public float score = 10f;

    public void TakeDamage (float amount, GameObject friendlyProjectile)
    {

        
        health -= amount;
        if (health <= 0f)
        {
            PlayerController lastHittingPlayer = friendlyProjectile.transform.GetComponent<FriendlyProjectile>().getShootingPlayer().transform.GetComponent<PlayerController>();
            lastHittingPlayer.addScore(score);
            lastHittingPlayer.updateScoreBoard();

            Debug.Log("The player has a score of: " + lastHittingPlayer.transform.GetComponent<PlayerController>().getScore());

            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    

}
