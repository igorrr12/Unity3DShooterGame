using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
   private float horizontalInput;
   private float verticalInput;
   private Vector3 direction;
   public float moveSpeed;
   private bool onGround;
   private bool canJump;
   private Rigidbody rb;
   public float drag;
   public float jumpForce;
   public LayerMask ground;
   public float playerHeight;
   public float airDrag;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = transform.forward * verticalInput + transform.right * horizontalInput;

        if (onGround) {
            rb.drag = drag;
        }
        else {
            rb.drag = airDrag;
        }

        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.7f, ground);

        JumpInput();
    }

    void FixedUpdate() {
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
        if (canJump) {
            Jump();
            canJump = false;
        }
    }

    void JumpInput() {
        if (Input.GetKeyDown(KeyCode.Space) && onGround){
            canJump = true;
        }
    }

    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
