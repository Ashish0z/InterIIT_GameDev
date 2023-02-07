using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player Dead!!!");
            playerDead = true;
            Destroy(gameObject);
        }
    }
    public void DecreaseHealth(float hitAmount)
    {
        health -= hitAmount;
    }
}
