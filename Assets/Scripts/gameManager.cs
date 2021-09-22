using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject rain;
    public Text scoreText;
    public Text timeText;
    public GameObject panel;

    public static gameManager I;

    int totalScore = 0;
    float limit = 5f;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0.0f, 0.5f);
        initGame();
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        limit = 5.0f;
        totalScore = 0;
    }
    void makeRain()
    {
        Instantiate(rain);
    }   
    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            limit = 0.0f;
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        timeText.text = limit.ToString("N2");
        if (Input.touchCount > 0 ) 
        {
            if(Input.GetTouch(0).position.x > (Screen.width / 2))
            {
                Debug.Log("right");
            }
            else
            {
                Debug.Log("left");
            }
        }
    }
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
