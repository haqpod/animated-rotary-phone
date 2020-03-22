using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneProjectileTwo : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 8f);
    }

    void Start()
    {
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1"))
        {
            
            gameObject.SetActive(false);
        }

        /*else if (other.CompareTag("player1projectile"))
        {
            
            gameObject.SetActive(false);
        } */
    }
}
