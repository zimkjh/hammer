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
    public Text leaderBoardText;
    private float feverTimer;
    private bool startedFeverTime;
    private string maxScoreKey = "maxScore";
    private List<int> savedMaxScores = new List<int> { 0, 0, 0, 0, 0 };
    private float feverTrigger;
    public bool isGameOver = false;

    public static GameManager I;

    int totalScore = 0;
    float limit = 60f;

    private void Awake()
    {
        I = this;
        savedMaxScores = new List<int>();
        for(int i = 0; i < 5; i++)
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
        limit = 60.0f;
        totalScore = 0;
        startedFeverTime = false;
        feverTimer = 3f;
        feverTrigger = 0f;
        isGameOver = false;
    }
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            limit = 0.0f;
            GameOver();
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
            feverTrigger = Mathf.Max(0, feverTrigger - 0.02f * Mathf.Sqrt(totalScore));
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
            if(i < 4)
            {
                leaderBoardText.text += "\n";
            }
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