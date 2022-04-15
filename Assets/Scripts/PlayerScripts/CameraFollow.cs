using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Declaring variables
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    //Late update works simiarly to update however it doesnt cause gitteryness and camera issues.
    private void FixedUpdate()
    {
        //This will get the cameras desired target position and follow them
        transform.position = target.position + offset;
    }
    //void FixedUpdate()
    //{
    //    Vector3 desiredPosition = target.position + offset;
    //    Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPostion;
    //    transform.LookAt(target);
    //}
}
