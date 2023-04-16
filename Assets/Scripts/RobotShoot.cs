using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShoot : MonoBehaviour
{
    public GameObject bullet;
    private float shootTimer;
    public float shootDelay;
    private GameObject player;
    public float maxDistanceToShoot;
    public float bulletSpeed;
    private bool canShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootDelay;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude <= maxDistanceToShoot) {
            if (shootTimer > 0) {
                shootTimer -= Time.deltaTime;
            } else {
                canShoot = true;
                shootTimer = shootDelay;
            }
        }
    }


    void FixedUpdate() {
        if (canShoot) {
            Shoot();
            canShoot = false;
        }
    }
    void Shoot() {
        GameObject spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody bulletRb = spawnedBullet.GetComponent<Rigidbody>();
        bulletRb.velocity = -spawnedBullet.transform.right * bulletSpeed;
    }
}
