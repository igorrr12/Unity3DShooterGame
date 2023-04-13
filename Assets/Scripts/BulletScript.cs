using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float flySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.forward * flySpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider) {
        if (!collider.gameObject.CompareTag("Gun")){
            Destroy(gameObject);
        }
    }
}
