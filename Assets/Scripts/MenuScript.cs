using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    private float highScore;
    public GameObject highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (highScore != 0)
            highScoreText.GetComponent<Text>().text += highScore + "s";
        else
            highScoreText.GetComponent<Text>().text += "-";
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.GetComponent<Text>().text = "High Score: ";
        Start();
    }
}
