using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    Transform cam;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    void Update ()
    {
        float xRotation = cam.transform.eulerAngles.x;
        float yRotation = cam.transform.eulerAngles.y;

        transform.eulerAngles = new Vector3(xRotation, yRotation, transform.eulerAngles.z);
	}
}
