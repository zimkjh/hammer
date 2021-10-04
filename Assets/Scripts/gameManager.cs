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
    public Text maxScoreText;
    private float feverTimer;
    private bool startedFeverTime;
    private string maxScoreKey = "maxScore";
    private int savedMaxScore = 0;

    public static GameManager I;

    int totalScore = 0;
    float limit = 50f;

    private void Awake()
    {
        I = this;
        savedMaxScore = PlayerPrefs.GetInt(maxScoreKey, 0);
        maxScoreText.text = savedMaxScore.ToString();
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
        startedFeverTime = false;
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
        if (totalScore == 10 && !startedFeverTime) { 
            feverTime = true;
            feverBird(feverTime);
            startedFeverTime = true;
        }
        if (feverTime == true)
        {
            feverTimer += Time.deltaTime;
        }
        if(feverTimer > 3f)
        {
            feverTime = false;
            feverBird(feverTime);
            feverTimer = 0;
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
        if(savedMaxScore < totalScore)
        {
            PlayerPrefs.SetInt(maxScoreKey, totalScore);
            savedMaxScore = totalScore;
            maxScoreText.text = totalScore.ToString();
        }
    }
    private void feverBird(bool isFever)
    {
        GameObject.Find("bird" + 0).GetComponent<Renderer>().enabled = !isFever;
        GameObject.Find("bird" + 1).GetComponent<Renderer>().enabled = !isFever;
        GameObject.Find("bird" + 100).GetComponent<Renderer>().enabled = isFever;
        GameObject.Find("bird" + 101).GetComponent<Renderer>().enabled = isFever;
    }
}
