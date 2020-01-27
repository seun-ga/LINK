using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
public Camera cam;

public float rotateSpeed = 5f;
public Rigidbody rb;
public float cameraRotationLimit = 80f;

private Vector3 rotation = Vector3.zero;
private float camerarotation = 0f;
private float currentCameraRotation = 0f;

void Update()
{
    float yRot = Input.GetAxisRaw("Mouse X");
    float xRot = Input.GetAxisRaw("Mouse Y");

    rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
    camerarotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)
}

void FixedUpdate() //Movement Rotation
{
    PreformRotation();
}

void PreformRotation() //X, Y회전
{
    rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    if(cam != null)
    {
        currentCameraRotation -= camerarotation;
        currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
        cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
    }
}
}