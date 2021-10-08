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
    public bool feverTime;
    public Text maxScoreText;
    private float feverTimer;
    private bool startedFeverTime;
    private string maxScoreKey = "maxScore";
    private int savedMaxScore = 0;
    private float feverTrigger;

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
        feverTimer = 3f;
        feverTrigger = 0f;
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
        if (feverTrigger > 100f && !startedFeverTime)
        {
            feverTime = true;
            feverBird(feverTime);
            startedFeverTime = true;
        }
        if (feverTime == true)
        {
            feverTrigger = 0;
            feverTimer -= Time.deltaTime;
            FeverGauge.I.changePercent(feverTimer / 3 * 100f);
        }
        else
        {
            feverTrigger -= 0.02f * Mathf.Sqrt(totalScore);
            FeverGauge.I.changePercent(feverTrigger);
        }
        if (feverTimer <= 0f)
        {
            feverTime = false;
            feverBird(feverTime);
            feverTimer = 3f;
            startedFeverTime = false;
        }
    }
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }
    public void addFeverTrigger()
    {
        feverTrigger += 10f;
    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameOver()
    {
        GameObject.Find("feverbar").GetComponent<Renderer>().enabled = false;
        GameObject.Find("feverGauge").GetComponent<Renderer>().enabled = false;
        panel.SetActive(true);
        Time.timeScale = 0;
        if (savedMaxScore < totalScore)
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
