using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float movementSpeed;
    public GameObject camera;


    public GameObject playerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;

    private Transform bulletSpawned;

    public float points;

    // Update is called once per frame
    void Update()
    {
        //payer fsacinh mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetPoint.x = 0;
            targetPoint.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        //Player movement
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        //Walking animaton
        

            //shooting
            if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

}
