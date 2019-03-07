using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRadius : MonoBehaviour {

    public bool detected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = false;
        }
    }
}
