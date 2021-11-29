using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text txScore;
    public Text txHighScore;
    Text txSelamat;
    int highscore;

    // Use this for initialization
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HS", 0);
        if (Data.score > highscore)
        {
            highscore = Data.score;
            PlayerPrefs.SetInt("HS", highscore);
        }
        else if (EnemyController.EnemyKilled == 3)
        {
            SceneManager.LoadScene("Congratulations");
        }
        txHighScore.text = "Highscores: " + highscore;
        txScore.text = "Scores: " + Data.score;
    }

    public void Replay()
    {
        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void Congratulation()
    {

        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene("Congratulation");
    }
    public void Menus()
    {
        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quited!");

    }

    public void Replay2()
    {
        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene("Gameplay 1");

    }

    public void Replayname()
    {
        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene(name);

    }
}