using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManagment : MonoBehaviour
{
    public int score, scoreEnd;
    public int lives;
    public bool isHurt, isGameRunning;
    public TextMeshProUGUI scoreText, livesText, highScoreText;
    public List<GameObject> livesHearts;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
       // livesText.text = "Lives:";
        isHurt = false;
        isGameRunning = true;
        lives = livesHearts.Count;

    }

    // Update is called once per frame
    void Update()
    {
        

       

       

        if (isHurt && isGameRunning)
        {
            isHurt = false;
            livesHearts[lives - 1].SetActive(false);
            lives -= 1;
            //livesText.text = "Lives:";
        }

        if (lives == 0)
        {
            isGameRunning = false;
            gameOverScreen.SetActive(true);
        }

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        //fix 
    }

    public void ScoreChanged()
    {
        scoreText.text = "Score: " + score;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;

    }

}
