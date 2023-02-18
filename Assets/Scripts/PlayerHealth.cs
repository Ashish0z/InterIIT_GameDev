using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Scoreboard scoreboard;
    Movement movement;
    BowShoot bowShoot;
    spawnEnemy SpawnEnemy;
    public float score;
    public float accuracy = 0;
    public int N, D;
    public int Level;
    Canvas scoreCanva;
    

    public float health = 100f;
    public bool playerDead = false;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(100f);
        movement = GetComponent<Movement>();
        SpawnEnemy = GameObject.FindGameObjectWithTag("spawn").GetComponent<spawnEnemy>();
        bowShoot = GetComponentInChildren<BowShoot>();
        //scoreCanva = GameObject.FindGameObjectWithTag("scoreCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        N = 4*SpawnEnemy.TotalEnemiesKilled;
        D = (bowShoot.NoofShotsFired + 1);
        accuracy = (float)N / (float)D;
        

        score = Mathf.RoundToInt(10*Mathf.Exp(accuracy));
        if (health <= 0)
        {
            Debug.Log("Player Dead!!!");
            playerDead = true;
            Debug.Log(score);
            //SceneManager.LoadScene(3);          
            //Destroy(gameObject);
            gameOver();
        }
    }
    public void gameOver()
    {
        scoreboard.Setup(score);
    }
    public void DecreaseHealth(float hitAmount)
    {
        health -= hitAmount;
        healthBar.SetHealth(health);
    }
}
