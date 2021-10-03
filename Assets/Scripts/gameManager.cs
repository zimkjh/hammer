using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public GameObject panel;
    public List<GameObject> blockList;
    public Text scoreText;
    public Text timeText;
    public bool feverTime;

    public static GameManager I;

    int totalScore = 0;
    float limit = 50f;

    private void Awake()
    {
        I = this;
        Screen.SetResolution(760, 1280, true);
    }

    void Start()
    {
        initGame();
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        limit = 50.0f;
        totalScore = 0;
    }
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
        if(totalScore > 10)
        {
            feverTime = true;
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
    public void GameOver()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
