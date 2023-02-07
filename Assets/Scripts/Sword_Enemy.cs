using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public bool enemyDead = false;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;
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
        //timeBtwAttacks = startTimeBtwAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0f)
        {
            enemyDead = true;
            Destroy(gameObject);
        }
        if (!enemyDead && Arjuna.GetComponent<PlayerHealth>() != null)
        {
            EnemyAI();
        }


    }

    private void EnemyAI()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) > stoppingDistance)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (Time.time >= nextAttackTime)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                nextAttackTime = Time.time + 1 / attackRate;
                Debug.Log("Player Hit!");
            }
            transform.position = this.transform.position;
        }
        //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    anim.SetBool("isWalking", true);
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}
        //if (timeBtwAttacks <= 0)
        //{
        //    //Vector2 arrow_start_pos = new Vector2(transform.position.x, transform.position.y + 0.66f);
        //    //Instantiate(projectile, arrow_start_pos, Quaternion.identity);
        //    anim.SetBool("isAttacking", true);
        //    Arjuna.GetComponent<PlayerHealth>().DecreaseHealth(5f);
        //    Debug.Log("Player Hit!");
        //    timeBtwAttacks = startTimeBtwAttacks;
        //}
        //else
        //{
        //    timeBtwAttacks -= Time.deltaTime;
        //}
    }
}
