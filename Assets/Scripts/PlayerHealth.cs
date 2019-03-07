using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;                         // The amount of health the player starts the game with.
    public static int currentHealth;                    // The current health the player has.

    public SimpleHealthBar healthBar;
    public Image damageImage;                           // Reference to an image to flash on the screen on being hurt.

    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;                                  // Reference to the player's movement.
    Animator anim;

    bool Dead;                                                      // Whether the player is dead.
    float restartTimer = 0f;
    float restartDelay = 5f;

    public float flashSpeed = 5f;                                   // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);         // The colour the damageImage is set to, to flash.

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        currentHealth = maxHealth;
    }


    void Update()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Death();
            restartTimer += Time.deltaTime;
        }

        if(restartTimer >= restartDelay)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    public void TakeDamage(int amount)
    {
        /*
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        */
    }

    
    void Death()
    {
         Dead = true;

         playerMovement.enabled = false;
         playerAttack.enabled = false;
    }
    
}