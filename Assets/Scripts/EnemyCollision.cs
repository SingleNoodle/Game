using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public bool enemyHit = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyHit = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyHit = false;
        }
    }

}
