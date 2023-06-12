using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Variables
    float speed = 30f;
    float turnSpeed = 30f;
    float verticalInput;
    float horizontalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the user's input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
