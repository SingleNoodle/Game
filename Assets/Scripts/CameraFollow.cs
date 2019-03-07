using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float turnSpeed = 3f;

    bool click = false;

    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        offset = new Vector3(target.position.x, target.position.y + 3.2f, target.position.z - 5.0f);
    }

    void Update()
    {
        click = Input.GetMouseButton(1);
    }

    void LateUpdate()
    {
        if (click == true)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        }

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}