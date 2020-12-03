using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerTiltAngle;
    public Boundary boundary;
    public Transform bulletManager;

    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            bulletClone.transform.SetParent(bulletManager);
            //GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        }
    }


    void FixedUpdate()
    {
        //movement

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerRB.velocity = movement * playerSpeed;

        playerRB.position = new Vector3
        (
            Mathf.Clamp(playerRB.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(playerRB.position.z, boundary.zMin, boundary.zMax)
        );

        //playerRB.rotation = Quaternion.Euler(0.0f, 0.0f, playerRB.velocity.x * -playerTiltAngle) ;

        playerRB.rotation = Quaternion.Euler(Vector3.forward * moveHorizontal * -playerTiltAngle);


    }

   
}
