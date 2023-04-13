using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public float sensitivity;
    public Camera _camera;
    private float cameraRotationX;
    private float cameraRotationY;

    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX =  Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        mouseY =  Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        cameraRotationY += mouseX;
        cameraRotationX -= mouseY;

        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);
        _camera.transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);
        transform.rotation = Quaternion.Euler(0, cameraRotationY, 0);
    }
}
