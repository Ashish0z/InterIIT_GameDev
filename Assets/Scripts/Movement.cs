using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Scoreboard scoreboard;
    PlayerHealth playerHealth;
    [SerializeField] float speed;
    [SerializeField] Animator horseAnim;
    public int I;
    public int Level;
    public AudioSource horseSound;
    public AudioSource introMusic;
    public AudioSource bgMusic;


    //[SerializeField] Transform playerLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        Level = I + 1;
        Debug.Log(Level);
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        checkSound();
        
    }

    void movement()
    {
        float moveAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveAmount, 0, 0);
        if(moveAmount != 0)
        {
            horseAnim.SetBool("isMoving", true);
            if (!horseSound.isPlaying) { horseSound.Play(); }
        }
        else
        {
            horseAnim.SetBool("isMoving", false);
            horseSound.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="finishline")
        {

            scoreboard.Setup(playerHealth.score);
            SceneManager.LoadScene(I + 1);

        }
    }
    void checkSound()
    {
        if (!introMusic.isPlaying)
        {
            if (!bgMusic.isPlaying)
            {
                bgMusic.Play();
            }
        }
    }

}