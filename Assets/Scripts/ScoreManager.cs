using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public AudioSource Hi;
    public static ScoreManager instance; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
   
    //Default score,
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //This display the points and highscore on the screen
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Points: " + score.ToString();
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint()
    {
        //This is so our game will add points and highscore into the system meaning plus 1
        score += 1;
        Hi.Play();
        scoreText.text = "Points: " + score.ToString();
        if (highscore < score)
        PlayerPrefs.SetInt("highscore", score);
    }
}
