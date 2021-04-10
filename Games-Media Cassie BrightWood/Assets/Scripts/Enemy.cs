using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    public float health;
    public float pointsToGive;

    public GameObject player;
    // methoods
    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);

        player.GetComponent<Player>().points += pointsToGive;
    }
}
