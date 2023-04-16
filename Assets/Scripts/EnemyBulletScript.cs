using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    void Start() {
        Destroy(gameObject, 3f);
    }
    
    void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Robot")) {
            Destroy(gameObject);
        }
    }
}
