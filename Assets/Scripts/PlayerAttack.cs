using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static int damagePerShot = 20;                  // The damage inflicted by attack.
    public Collider attackHitBox;

    float AttackCooldown = 1.05f;                   // The time between each attack.
    float timer;                                    // A timer to determine when to attack.
    float damagetimer = 1.0f;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attackHitBox.enabled = false;

        timer += Time.deltaTime;
        damagetimer += Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.Z) && timer >= AttackCooldown)
        {
            Attack(attackHitBox);
        }
        else if (Input.GetMouseButton(0) && timer >= AttackCooldown)
        {
            Attack(attackHitBox);
        }
    }

    void Attack(Collider col)
    {
        timer = 0f;
        damagetimer = 0f;

        anim.SetTrigger("Attack1Trigger");
    }

    void HitEvent()
    {
        attackHitBox.enabled = true;
    }
}

