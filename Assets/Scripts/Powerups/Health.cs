using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float healing = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerTarget target = collision.transform.GetComponent<PlayerTarget>();

            if (target != null)
            {
                target.TakeHealing(healing);
            }

            Debug.Log("Health collided with something!");

            Destroy(this.gameObject);
        }
    }

}
