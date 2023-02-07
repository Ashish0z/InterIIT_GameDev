using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public float speed;
    public float damage;

    private Transform player;
    private Vector2 target;
    private GameObject Arjuna;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Arjuna = GameObject.FindGameObjectWithTag("Player");
        target = new Vector2(player.position.x, player.position.y);
        gameObject.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject, 0.2f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            //Arjuna.GetComponent<Arjun_health>().health -= 10;
            //Debug.Log("Player Hit!");
            Arjuna.GetComponent<PlayerHealth>().DecreaseHealth(damage);
            Destroy(gameObject, 0.2f);

        }
    }
}
