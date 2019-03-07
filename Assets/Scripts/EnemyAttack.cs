using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damagePerShot = 10;              // The damage inflicted by attack.
    Collider attackHitbox;

    float distance = 6f;

    float AttackCooldown = 2f;                  // The time between each attack.
    float timer = 1f;                           // A timer to determine when to attack.

    EnemyHealth enemyHealth;

    Animator anim;

    void Awake()
    {
        attackHitbox = GetComponent<Collider>();
        enemyHealth = GetComponent<EnemyHealth>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.playerTran.position) <= distance && EnemyMovement.Moving == false && enemyHealth.currentHealth > 0)
        {
            timer += Time.deltaTime;

            if (timer >= AttackCooldown)
            {
                Attack(attackHitbox);
            }
        }
    }

    void Attack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Player"));
        foreach (Collider c in cols)
        {
            if (c.name == "2Handed Warrior")
            {
                timer = 0f;

                anim.SetTrigger("slime_attack");
            }
        }
    }

    void AttackEvent()
    {
        PlayerHealth.currentHealth -= damagePerShot;
    }
}
