using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool health = true;
    bool detect = false;
    int detectedValue = 0;

    SphereCollider enemy;

    public int currentHealth; //enemy health

    Animator anim;

    public static bool Moving;

    UnityEngine.AI.NavMeshAgent nav;
    
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();

        enemy = GetComponent<SphereCollider>();
    }

    void Update()
    { 
        CheckHealth();
        CheckDetect();

        if (detect == true && health == true)
        {
            nav.enabled = true;
            nav.SetDestination(PlayerMovement.playerTran.position);

            Moving = true;
            anim.SetBool("Moving", Moving);
        }
        else
        {
            nav.enabled = false;

            Moving = false;
            anim.SetBool("Moving", Moving);
            //MoveRandom();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyDetect")
        {
            detectedValue++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemyDetect")
        {
            detectedValue--;
        }
    }

    void CheckDetect()
    {
        if(detectedValue > 0)
        {
            detect = true;
        }
        else
        {
            detect = false;
        }
    }

    void CheckHealth()
    {
        if (gameObject.GetComponent<EnemyHealth>().currentHealth > 0 && PlayerHealth.currentHealth > 0)
        {
            health = true;
        }
        else
        {
            health = false;
        }
    }

void MoveRandom()
    {
        //no time
    }
}
