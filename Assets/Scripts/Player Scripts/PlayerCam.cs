using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielCairney
{
  
    public class PlayerCam : MonoBehaviour
    {  
        public float sensX;
        public float sensY;

        public Transform orientation;

        float xRotation;
        float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible= false;
        }

        private void Update()
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

            yRotation += mouseX;
            xRotation -= mouseY; 
            // Makes it so the player cannot look further up or down then 90 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //Rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

}