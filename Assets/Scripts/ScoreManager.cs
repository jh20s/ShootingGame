using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : SingleToneMaker<ScoreManager>
{
    public Text currentScoreUI;
    public Text bestScoreUI;
    private int bestScore;
    private int currentScore;


    

    void Awake()
    {
        GameObject.Find("Player").GetComponent<PlayerState>().PlayerResetEventSet(PlayerReset);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentScoreUI.text = "현재 점수 : " + currentScore;
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재 점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }


    public void PlayerReset()
    {
        Score = 0;
    }
}
