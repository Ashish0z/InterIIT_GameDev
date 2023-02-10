using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject swordguy, archer, Player;
    public float time = 0;
    Enemy enemy;
    Sword_Enemy sword_Enemy;
    PlayerHealth playerHealth;
    public int MaxNoofEnemies ;
    public int Noofarchergenreted = 1;
    public int NoofswordGuygenreted = 1;
    public int NoofEnemiesgenreted;
    public int noOfArcherKilled = 0;
    public int swordguykillled = 0;
    public int MaxinTotal;
    public int ZEXY;
    public int L = 0;
    public int TotalEnemiesKilled = 0;


    private void Start()
    {
       
        enemy = archer.GetComponent<Enemy>();
        sword_Enemy = swordguy.GetComponent<Sword_Enemy>();
        playerHealth = Player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        if (playerHealth.health > 0)
        { time += Time.deltaTime; }

        if(ZEXY==0)
        {
            spawn_S(9f, new Vector3(90, 0, 0));
            spawn_A(9f, new Vector3(135, 0, 0));
        }
        if (ZEXY == 1)
        {
            spawn_S(9f, new Vector3(90, 0, 0));
            spawn_S(9f, new Vector3(90, 0, 0));
            spawn_A(9f, new Vector3(135, 0, 0));
        }
        if(ZEXY==2 && time<60f)
        {
            spawn_S(9f, new Vector3(90, 0, 0));
            spawn_S(9f, new Vector3(90, 0, 0));
            spawn_A(9f, new Vector3(135, 0, 0));
        }
        if (ZEXY == 2)
        {
            spawn_B(55f, new Vector3(135, 0, 0));
        }
        TotalEnemiesKilled = noOfArcherKilled + swordguykillled ;

       
        //spawn_S(13f, new Vector3(110, 0, 0));
        // spawn_S(13f, new Vector3(110, 0, 0));
        //spawn_S(13f, new Vector3(110, 0, 0));
        //spawn_S(16f, new Vector3(110, 0, 0));
        //spawn_A(16f, new Vector3(90, 0, 0));

        //spawn_S(20f, new Vector3(140, 0, 0));
        //spawn_S(20f, new Vector3(140, 0, 0));
        //spawn_S(20f, new Vector3(140, 0, 0));
        //spawn_A(20f, new Vector3(140, 0, 0));
        //spawn_A(20f, new Vector3(140, 0, 0));

        NoofEnemiesgenreted = Noofarchergenreted + NoofswordGuygenreted;
    }

    void spawn_S(float t, Vector3 spawnpoint)
    {
        if (time >= t && (NoofEnemiesgenreted - (noOfArcherKilled + swordguykillled)) < MaxNoofEnemies && NoofEnemiesgenreted <= MaxinTotal)
        {
            Instantiate(swordguy, spawnpoint, Quaternion.Euler(0, 180, 0));
            NoofswordGuygenreted++;
        }
    }
    void spawn_A(float t, Vector3 spawnpoint)
    {
        if (time >= t && (NoofEnemiesgenreted - (noOfArcherKilled + swordguykillled)) < MaxNoofEnemies && NoofEnemiesgenreted <= MaxinTotal)
        {
            Instantiate(archer, spawnpoint, Quaternion.Euler(0, 180, 0));
            Noofarchergenreted++;
        }
    }
    void spawn_B(float t, Vector3 spawnpoint)
    {
        if (time >= t && (NoofEnemiesgenreted - (noOfArcherKilled + swordguykillled)) < MaxNoofEnemies && NoofEnemiesgenreted <= MaxinTotal && L<1)
        {
            Instantiate(swordguy, spawnpoint, Quaternion.Euler(0, 180, 0));
            NoofswordGuygenreted++;
            L++;
        }
    }
}