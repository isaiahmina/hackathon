using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;

    void LateUpdate()
    {
        transform.position = new Vector3(
            target.position.x, target.position.y, -10);

        transform.position = Vector3.SmoothDamp(
            transform.position, target.position, ref _velocity, smoothTime);
    }
}
