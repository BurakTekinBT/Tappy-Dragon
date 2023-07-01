using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int score;
    int highScore;
    Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject NewHighScore;
    public GameObject fireballActive;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString(); 

    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score  > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore",highScore);  //Database kullanmadan datalarý yazýp alabildiðimiz kýsým
            NewHighScore.SetActive(true);
        }
        if (score > 5)
        {
            fireballActive.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
