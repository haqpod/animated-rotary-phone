using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Healthbar healthbar;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public float bottomScreenEdge;
    public float topScreenEdge;
    public GameObject playerone;
    public GameManager gm;
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField]
    private float speed;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Cursor.visible = false;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (gm.gameOver)
        { 
            return;
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            return;
        } */

        float move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized
     * speed * Time.deltaTime;

        if (move < 0 && facingRight)
        {
            flip();
        }

        else if (move > 0 && !facingRight)
        {
            flip();
        }


     animator.SetFloat("moveX", rb.velocity.x);
     animator.SetFloat("moveY", rb.velocity.y);
   
     if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
     {
      animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
     }

     /*if (transform.position.x < leftScreenEdge)
     {
      transform.position = new Vector2(leftScreenEdge, transform.position.y);
     }
     
     if (transform.position.x > rightScreenEdge)
     {
      transform.position = new Vector2(rightScreenEdge, transform.position.y);
     }

        // up down movement and block player from going out of top and bottom of canvas  
     if (transform.position.y < bottomScreenEdge)
     {
      transform.position = new Vector2(transform.position.x, bottomScreenEdge);
     }
     if (transform.position.y > topScreenEdge)
     {
       transform.position = new Vector2(transform.position.x, topScreenEdge);
     }
     */
    }

    void flip()
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

    void TakeDamage(int damage)
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


