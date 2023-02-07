using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public bool enemyDead = false;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float enemyHealth = 20f;

    public GameObject projectile;
    private Transform player;
    private GameObject Arjuna;
    Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Arjuna = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0f)
        {
            enemyDead = true;
            Destroy(gameObject);
        }
        if (!enemyDead || !Arjuna.GetComponent<PlayerHealth>().playerDead)
        {
            EnemyAI();
        }


    }

    private void EnemyAI()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            anim.SetBool("isWalking", false);
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Vector2 arrow_start_pos = new Vector2(transform.position.x, transform.position.y + 0.66f);
            Instantiate(projectile, arrow_start_pos, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
