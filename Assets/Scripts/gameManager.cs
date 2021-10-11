using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public GameObject panel;
    public Text scoreText;
    public bool feverTime;
    public Text leaderBoardText;
    public GameObject ready;
    public GameObject go;
    public GameObject readyPanel;
    private int totalScore = 0;
    private float feverTimer;
    private bool startedFeverTime;
    private string maxScoreKey = "maxScore";
    private List<int> savedMaxScores = new List<int> { 0, 0, 0, 0, 0 };
    private float feverTrigger;
    public bool isGameOver = false;
    public bool isReady = true;
    private float readyTime = 1f;

    public static GameManager I;


    private void Awake()
    {
        I = this;
        savedMaxScores = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            savedMaxScores.Add(PlayerPrefs.GetInt(maxScoreKey + "_" + i, 0));
        }
    }

    void Start()
    {
        initGame();
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        startedFeverTime = false;
        feverTimer = 3f;
        feverTrigger = 0f;
        isGameOver = false;
        isReady = true;
        readyTime = 1f;
    }
    void Update()
    {
        if (isReady)
        {
            readyTime -= Time.deltaTime;
            if (readyTime < 0.5f)
            {
                ready.SetActive(false);
                go.SetActive(true);
            }
            if (readyTime < 0f)
            {
                readyPanel.SetActive(false);
                isReady = false;
            }
        }
        if (feverTrigger > 100f && !startedFeverTime)
        {
            feverTime = true;
            BirdAnim.I.feverBird(feverTime);
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
            feverTrigger = Mathf.Max(0, feverTrigger - 0.02f * Mathf.Sqrt(totalScore));
            FeverGauge.I.changePercent(feverTrigger);
        }
        if (feverTimer <= 0f)
        {
            feverTime = false;
            BirdAnim.I.feverBird(feverTime);
            feverTimer = 3f;
            startedFeverTime = false;
        }
    }
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }
    public int getScore()
    {
        return totalScore;
    }
    public void addFeverTrigger()
    {
        feverTrigger += 5f;
    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameOver()
    {
        BirdAnim.I.gameOverBird();
        isGameOver = true;
        GameObject.Find("feverbar").GetComponent<Renderer>().enabled = false;
        GameObject.Find("feverGauge").GetComponent<Renderer>().enabled = false;
        GameObject.Find("MainScore").SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0;
        if (savedMaxScores[4] < totalScore)
        {
            savedMaxScores[4] = totalScore;
            savedMaxScores.Sort();
            savedMaxScores.Reverse();
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt(maxScoreKey + "_" + i, savedMaxScores[i]);
            }
        }
        leaderBoardText.text = "";
        List<string> leaderBoardEng = new List<string> { "st", "nd", "rd", "th", "th" };
        for (int i = 0; i < 5; i++)
        {
            leaderBoardText.text += ((i + 1).ToString() + leaderBoardEng[i] + " ");
            int scoreLength = savedMaxScores[i].ToString().Length;
            leaderBoardText.text += new string('.', 11 - scoreLength);
            leaderBoardText.text += (" " + savedMaxScores[i]);
            if (i < 4)
            {
                leaderBoardText.text += "\n";
            }
        }
    }
}