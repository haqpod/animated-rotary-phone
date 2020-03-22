using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Boss1AI : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 50;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    //private Vector2 bulletMoveDirection;
    public int maxHealth = 15;
    public int currentHealth;

    public Healthbar healthbar;

    public Transform player1;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bossProjectile1;

    public float speed;

    public bool inPlay;
    public bool isInvulnerable = false;

    public GameManager gm;

    public GameObject bossone;
    public Transform B1explosion;
 
    public Transform moveSpot;
    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Rigidbody2D rb;

   
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("player1").transform;
        timeBtwShots = startTimeBtwShots;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossOneProjectileTwo>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }


    void Update()
    {
       
           if (gm.gameOver)
          {
            CancelInvoke();
              return;
          } 

         if (timeBtwShots <= 0)
         {
             Instantiate(bossProjectile1, transform.position, Quaternion.identity);
             timeBtwShots = startTimeBtwShots;
         }
         else
         {
             timeBtwShots -= Time.deltaTime;
         }     

        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position,
        speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1projectile"))
        {
            TakeDamage(1);
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}

class StateMachine
{
    // Health stages.
    private readonly int[] stages = { 13, 10, 6, 4, 3};
    private readonly Boss1AI _boss;

    public StateMachine(Boss1AI boss)
    {
        _boss = boss;
    }

    public void ChangeState(int health)
    {
        // Prefer to use state machine.
        // Extract these if statement.
        SetShootingIntensity(health);
        AngerBoss(health);

        var isDead = currentHealth <= 0;
        if (isDead)
        {
            KillBoss();
        }
    }

    private void SetShootingIntensity(int currentHealth)
    {
        if (currentHealth <= stages[0])
        {
            _boss.startTimeBtwShots = 3f;
        }
        else if (currentHealth <= stages[1])
        {
            _boss.startTimeBtwShots = 0.7f;
        }
        else if (currentHealth <= stages[4])
        {
            _boss.startTimeBtwShots = 0.5f;
        }
    }

    private void AngerBoss(int currentHealth)
    {
        if (currentHealth <= stages[0])
        {
            EnterPhase();
        }
        else if (currentHealth <= stages[2])
        {
            EnterPhase();
        }
    }

    // Can do more things than just firing.
    private void EnterPhase()
    {
        _boss.InvokeRepeating("Fire", 3, 5);
    }

    private void KillBoss()
    {
        // Let unity handle the hiding.
        // Destroying is a heavy operation.
        _boss.SetAcitve(false);
        _boss.Transform newExplosion = Instantiate(B1explosion, transform.position, transform.rotation);
        _boss.Destroy(newExplosion.gameObject, 6.5f);
    }
}


