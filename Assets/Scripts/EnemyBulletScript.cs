using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public int damage;
    void Start() {
        Destroy(gameObject, 2f);
    }
    
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Hit.zslkndkjabjdbw");
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Health>().health -= damage;
            Destroy(gameObject);
        }
    }
}
