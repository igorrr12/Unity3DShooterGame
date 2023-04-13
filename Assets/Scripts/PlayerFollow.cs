using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 position;
    public float yOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z);
        transform.position = position;
    }
}
