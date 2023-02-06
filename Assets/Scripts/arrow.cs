using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    
    Rigidbody2D rb;
    public bool hasHit = false;
    // Start is called before the first frame update
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
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        if (collision2D.gameObject.tag == "Ground") 
        {
           
            Destroy(gameObject, 0.2f);
 
        }
        
    }
}
