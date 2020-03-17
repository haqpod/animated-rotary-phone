using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject bullet;

    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    private Vector2 lookDirection;
    private float lookAngle;

    public GameManager gm;

    public Animator animator;


    //public Rigidbody2D rb;

    void Update()
    {

        if (gm.gameOver)
        {
            return;
        }

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if ((Input.GetMouseButtonDown(0)) && (Time.time >= nextTimeToFire))
        {
            animator.SetBool("castBall", true);
            nextTimeToFire = Time.time + 10f / fireRate;
            FireBullet();
        }
    }
    
    

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 4f;
    }
}