using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;                 // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.

    public SimpleHealthBar healthBar;

    EnemySpawning enemySpawning;
    GameObject enemyTran;

    bool enemyHit = false;
    float timer = 0f;
    float timerOld = 0f;

    Animator anim;                              // Reference to the animator.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;

        healthBar = GetComponentInChildren<SimpleHealthBar>();
    }

    void Update()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);

        if (timer > 0f)
        {
            if (enemyHit == false)
            {
                Debug.Log("Hit");
                TakeDamage(PlayerAttack.damagePerShot);
                enemyHit = true;
            }
        }

        if(timer == timerOld && enemyHit == true)
        {
            Debug.Log("Reset");
            timer = 0f;
            timerOld = 0f;
            enemyHit = false;
        }

        timerOld = timer;

        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            timer += Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");

        enemySpawning.numberOfSlimes = enemySpawning.numberOfSlimes - 1;
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;
        Destroy(gameObject, 2f);
    }
}