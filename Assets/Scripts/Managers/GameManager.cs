using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float score;
    private float healthBarMaxWidth;

    public GameObject gameOver;
    public GameObject winGamePanel;
    public float winScore, loseScore, startScore;
    public Image scoreBar, scoreBar2;
    public Image barBounds;
    public SoundManager soundManager;

    public float timeScale;

    public Animator launchAnimation;
    void Start()
    {
        healthBarMaxWidth = barBounds.rectTransform.rect.width;
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

    public void StartGamePlayOnDelay()
    {
        StartCoroutine(_launchGamePlayAfterDelay(0.8f));
    }

    private IEnumerator _launchGamePlayAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        StartGamePlay();
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
            Debug.Log(score);
            if (score < winScore)
            {
                float scoreRatio = (score / (winScore - loseScore));
                if (scoreRatio > 1) return;

                float width = healthBarMaxWidth * scoreRatio;

                scoreBar.rectTransform.sizeDelta = new Vector2(width, scoreBar.rectTransform.rect.height);
                scoreBar2.rectTransform.sizeDelta = new Vector2(0, scoreBar.rectTransform.rect.height);
            }
            else
            {
                float scoreRatio = ((score - winScore) / (winScore - loseScore));
                Debug.Log("score Ratio:"+scoreRatio);
                if (scoreRatio > 1) return;

                float width = healthBarMaxWidth * scoreRatio;
                scoreBar.rectTransform.sizeDelta = new Vector2(healthBarMaxWidth, scoreBar.rectTransform.rect.height);
                scoreBar2.rectTransform.sizeDelta = new Vector2(width, scoreBar.rectTransform.rect.height);

            }
        }

    }

    void updateScore()
    {

        updateScoreText();
        //Win
        if (score >= winScore)
        {
            this.timeScale = 3;
            if (score >= 2 * winScore)
            {
                Time.timeScale = 0;
                soundManager.StopAllMusic();
                soundManager.PlayGameWinMusic();
                StartGameWinWithDelay();
                scoreBar2.rectTransform.sizeDelta = new Vector2(healthBarMaxWidth, scoreBar.rectTransform.rect.height);
            }


        }
        //Loose
       else if (score <= loseScore)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            soundManager.StopAllMusic();
            soundManager.PlayGameOverMusic();
        }
        else
        {
            timeScale = 1;
        }

    }

    public void Die()
    {
        soundManager.Die();
    }

    void PlayWinGameRoutine() {
        winGamePanel.SetActive(true);

    }

    public void StartGameWinWithDelay()
    {
        StartCoroutine(_launchGameWinPaneAfterDelay(0.6f));
    }

    private IEnumerator _launchGameWinPaneAfterDelay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        PlayWinGameRoutine();
    }

    public void Exit()
    {

        Application.Quit();
    }
}
