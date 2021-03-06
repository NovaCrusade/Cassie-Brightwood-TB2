using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public float speed;
    public float maxDistance;

    private GameObject triggerEnemy;
    public float damage;
    // Methods
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 2)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
