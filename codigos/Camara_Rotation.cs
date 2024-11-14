using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Rotation : MonoBehaviour
{
     public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update() {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      float rotationX = vertical * rotationSpeed * Time.deltaTime;
      float rotationY = horizontal * rotationSpeed * Time.deltaTime;
      transform.Rotate(Vector3.right, -rotationX);
      transform.Rotate(Vector3.up, rotationY, Space.World);
    }
}
