using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Camera player_camera;

    public float rotateSpeed = 3f;

     public float zoomSpeed = 10.0f;
    public Rigidbody rb;
    public float cameraRotationLimit = 80f;

    private Vector3 rotation = Vector3.zero;
    private float camerarotation = 0f;
    private float currentCameraRotation = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        var mode=GameManager.GetInstance().mode;
        if(mode.Equals("intro")|mode.Equals("outro")){
            //intro/outro:시야가 에루탄에 고정되고 커서가 숨겨진다.
            cameraInitializtion(player_camera);
            player_camera.transform.LookAt(target); 
            Cursor.lockState = CursorLockMode.Locked;

        }else if(mode.Equals("inscene")){
             //inscene: 시야가 풀리고, 클릭가능한 물체들을 보면 표시가 나온다. 
             Zoom();
            Cursor.lockState = CursorLockMode.Locked;
            float yRot = Input.GetAxisRaw("Mouse X");
            float xRot = Input.GetAxisRaw("Mouse Y");

            rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
            camerarotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)   
        }
        
    }
    void FixedUpdate() //Movement Rotation
{   
    PreformRotation();
    
}

void PreformRotation() //X, Y회전
{
    var mode=GameManager.GetInstance().mode;
    rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    if(player_camera != null&& mode.Equals("inscene"))
    {
        currentCameraRotation -= camerarotation;
        currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);

        player_camera.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
    }
}

private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if(distance != 0)
        {
            float field=player_camera.fieldOfView + distance;
            player_camera.fieldOfView= Mathf.Clamp(field,20,60);
        }
    }



public void cameraInitializtion(Camera camera){
    camera.fieldOfView=60;
}

}
