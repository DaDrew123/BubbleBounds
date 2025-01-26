using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.13f; // Adjust for smoother camera movement ...

    void LateUpdate(){
        if (player != null){
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothPosition;
        }
    }

}
