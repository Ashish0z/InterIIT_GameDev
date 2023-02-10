using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //PlayerHealth playerHealth;
    //Movement movement;
    public int level;
    public TextMeshProUGUI scoreText;
    int i = 0;
    float[] Scooress;

    // Start is called before the first frame update
    //void Start()
    //{
    //    scoreText = GetComponentInChildren<TextMeshProUGUI>();
    //    playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    //    movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    //    scoreText.text = playerHealth.score.ToString();
    //}
    //// Update is called once per frame
    void Update()
    {
        //Debug.Log(movement.Level);
        if (Input.GetMouseButton(0))
        {
            //Scooress[i] = float.Parse(scoreText.text);
            SceneManager.LoadScene(level+1);
            i++;
        }
    }

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
    }
}
