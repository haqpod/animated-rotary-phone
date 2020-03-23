using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    public Transform projectileExplosion;
    public GameObject destroyEffect;
    public GameObject projectile;

    void Start()
    {
        // Avoid stringly-typed code.
        // Avoid it, because you will find that it doesn't work only when you run it.
        // So overall, if you can use strongly-typed code, do it.
        // In this example you changed stringly-typed to strongly-typed code.
        DestroyProjectile(lifeTime);
    }

    private void DestroyProjectile(float lifeTime)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("boss"))
        {
            Transform newExplosion = Instantiate(projectileExplosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);
            Destroy(projectile);


        }
    }
}
