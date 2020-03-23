using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    // Avoid magic values. A magic value is a value that you interact with out of no context.
    // Prefer to used named variabled- constants
    //private const string 

   // If you are tight on time, you can make a more pragmatic decision of
   // adding comments to code instead of splitting stuff.

    // Health
    public int maxHealth;
    public int currentHealth;
    public Healthbar healthbar;

    // Screen
    public float rightScreenEdge;
    public float leftScreenEdge;
    public float bottomScreenEdge;
    public float topScreenEdge;

    // Animation
    public GameObject playerone;
    public GameManager gm;
    public Rigidbody2D rb;
    public Animator animator;

    // Movement
    [SerializeField]
    private float speed;
    bool facingRight = true;
    
    // Awake should contain component initialization.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start should set the values of data.
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (gm.gameOver)
        { 
            return;
        }

        rb.velocity = Controls.MoveDiagonaly().normalized * speed * Time.deltaTime;

        // Put code as close as possible to where you use it.
        float move = Controls.MoveRight();
        // Prefer to explain the bool variables by explicitly explaining what bool it is.
        // For bool, we use is/can/has prefix.
        var isMovingLeft = move < 0;
        var isMovingRight = move > 0; 

        // So now the intention is more clear.
        if (isMovingLeft && facingRight || isMovingRight && !facingRight)
        {
            Flip();
        }

        animator.SetFloat(Animator.MoveX, rb.velocity.x);
        animator.SetFloat(Animator.MoveY, rb.velocity.y);
   
        if (Controls.MoveRight() == 1 || Controls.MoveUp() == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gm.gameOver)
        {
            return;
        } 

        if (other.CompareTag("boss"))
        {  
            TakeDamage(10);
            gm.UpdateLives(-100);
            animator.SetBool("isDead", true);         
            rb.velocity = new Vector2(0, 0);
        }

         else if(other.CompareTag("bossProjectile1"))
         {
            
            if(currentHealth >= 2)
            {
             animator.SetBool("isHurt", true);
            }
            TakeDamage(1);
         }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            gm.UpdateLives(-1);
            rb.velocity = new Vector2(0, 0); 
        }
    }
}


