using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrow : MonoBehaviour
{
    Rigidbody2D rb;
    public bool hasHit = false;
    public AudioSource arrowHitSound;
    public AudioSource arrowReleaseSound;
    // Start is called before the first frame update
    private void Awake()
    {
        arrowReleaseSound.Play();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag != "Enemy")
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;

        }
        //if (collision2D.gameObject.tag == "Player")
        //{
        //    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision2D.gameObject.GetComponent<Collider2D>());
        //}
        if (collision2D.gameObject.tag == "Ground")
        {
            Destroy(gameObject, 0.2f);

        }
        if (collision2D.gameObject.tag == "Player")
        {
            //if (collision2D.gameObject.GetComponent<Sword_Enemy>() != null)
            //{
            //    collision2D.gameObject.GetComponent<Sword_Enemy>().enemyHealth -= 10f;
            //}
            if (collision2D.gameObject.GetComponent<PlayerHealth>() != null)
            {
                collision2D.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(34f);
            }
            arrowHitSound.Play();
            Debug.Log("Player Hit!");
            Destroy(gameObject, 0.2f);

        }

    }
}
