using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotScript : MonoBehaviour
{
    private GameObject player;
    public float activationDistance;
    public float minDistanceToPlayer;
    public bool active;
    public float idleRotationSpeed;
    private NavMeshAgent navMeshAgent;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < activationDistance) {
            active = true;
        }

        if ((transform.position - player.transform.position).magnitude < minDistanceToPlayer) {
            active = false;
        }
        if (active) {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            navMeshAgent.destination = player.transform.position;
        } else {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotation.eulerAngles.y, 0), idleRotationSpeed * Time.deltaTime);
        }
    }
}
