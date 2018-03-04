using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 1f; // a little bit of lag to follow
    public float rotateSpeed = 3.0f;
    private float x = 0;
    private float height = 15, followDistance = -15;

    Vector3 offset; // offset between the player and the camera

    private void Start()
    {
        offset = new Vector3(0, height, followDistance);
    }

    private void FixedUpdate()
    {        
        x = Input.GetAxis("RightStickHorizontal") * rotateSpeed;
        
        offset = Quaternion.AngleAxis(x, Vector3.up) * offset;
        //offset = Quaternion.AngleAxis(y, Vector3.right) * offset;
        
        Vector3 targetCamPos = offset + target.position;

        //transform.position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.LookAt(target.position);
    }
}
