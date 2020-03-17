using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Projectile : MonoBehaviour
{
    public float speed;
    public GameObject B1PExplosion;
    public Rigidbody2D rb;
    public GameObject bossOneProjectile;
    public GameManager gm;

    private Transform player1;
    private Vector2 moveDirection;

     void Start()
     {
        /*if (gm.gameOver == true)
        {
            return;
        }

        else */

        player1 = GameObject.FindGameObjectWithTag("player1").transform;

        rb = GetComponent<Rigidbody2D>();

        moveDirection = (player1.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 14f);
     }

    void DestroyBoss1Projectile()
    {
        Instantiate(B1PExplosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1"))
        {
            DestroyBoss1Projectile();
            gameObject.SetActive(false);
        }

        /*else if (other.CompareTag("player1projectile"))
        {
            DestroyBoss1Projectile();
            gameObject.SetActive(false);
        } */
    }
}
