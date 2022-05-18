using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targPos, ref velocity, smoothTime);
    }
}
