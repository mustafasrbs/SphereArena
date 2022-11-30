using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private float horizontalInput;
   

  
    void Update()
    {
        RotateToCamera(); 
    }
    // pc controller
    void RotateToCamera()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
    }
    // mobile controller
    
}
