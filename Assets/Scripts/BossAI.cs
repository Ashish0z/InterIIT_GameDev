using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public bool bossDead = false;
    public float damage;
    public float bossHealth = 20f;

    public GameObject projectile;
    private Transform player;
    private GameObject Arjuna;
    public Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Arjuna = GameObject.FindGameObjectWithTag("Player");
        //anim = GetComponentInChildren<Animator>();
        //timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0f)
        {
            bossDead = true;
            Destroy(gameObject);
        }
        if (!bossDead && Arjuna.GetComponent<PlayerHealth>() != null)
        {
            EnemyAI();
        }


    }

    private void EnemyAI()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            anim.SetBool("isMoving", false);
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        //if (timeBtwShots <= 0)
        //{
        //    Vector2 arrow_start_pos = new Vector2(transform.position.x, transform.position.y + 0.66f);
        //    Instantiate(projectile, arrow_start_pos, Quaternion.identity);
        //    timeBtwShots = startTimeBtwShots;
        //}
        //else
        //{
        //    timeBtwShots -= Time.deltaTime;
        //}
    }
}
