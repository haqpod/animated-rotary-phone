using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float lifeTime;

    public Transform projectileExplosion;

    public GameObject destroyEffect;
    public GameObject projectile;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("boss"))
        {
            Transform newExplosion = Instantiate(projectileExplosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);
            Destroy(projectile);


        }
        /*else if (other.CompareTag("bossProjectile1"))
        {
            Transform newExplosion = Instantiate(projectileExplosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);
            Destroy(projectile);
        }*/
    }
}
