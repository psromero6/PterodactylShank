using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public GameObject gameOver;
    public int winScore, loseScore, startScore;
    public Image scoreBar;
    // Use this for initialization
    void Start()
    {

        score = startScore;
        Time.timeScale = 1;
        updateScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }
    public void StartGamePlay()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
        updateScoreText();
    }
    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ScoreIncrease(int points)
    {
        score += points;
        updateScore();
    }

    public void ScoreDecrease(int damage)
    {
        score -= damage;
        updateScore();
    }

    void updateScoreText()
    {
        //when score =winScore W=530, if score =lose Score w=30
        if ((winScore - loseScore) > 0)
        {
            float width = 400 * score / (winScore - loseScore);

            scoreBar.rectTransform.sizeDelta = new Vector2(width, scoreBar.rectTransform.rect.height);
        }
    }

    void updateScore()
    {

        updateScoreText();

        if (score >= winScore)
        {
            //Winn
        }
        if (score <= loseScore)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

    }


    public void Exit()
    {

        Application.Quit();
    }
}
