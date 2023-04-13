using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour
{
    public float spawnDelay;
    private float spawnTimer;
    public GameObject robot;

    
    void Start() {
        spawnTimer = spawnDelay;
    }
    
    
    void Update()
    {
        if (spawnTimer > 0) {
            spawnTimer -= Time.deltaTime;
        } else if (spawnTimer <= 0) {
            Spawn();
            spawnTimer = spawnDelay;
        }
    }

    void Spawn() {
        Instantiate(robot, transform.position, transform.rotation);
    }
}
