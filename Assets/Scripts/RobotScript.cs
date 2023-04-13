using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    private GameObject player;
    public float rotationSpeed;
    private Rigidbody rb;
    public float moveSpeed;
    public float minDistToPlayer;

    void Start() {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, rotation.eulerAngles.y, -90), rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
        if ((player.transform.position - transform.position).magnitude > minDistToPlayer) {
            rb.velocity = -transform.right * moveSpeed * Time.deltaTime;
        } else {
            rb.velocity = Vector3.zero;
        }
    }
}
