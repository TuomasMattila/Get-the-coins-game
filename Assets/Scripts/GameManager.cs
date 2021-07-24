using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private float scoreTime;
    private float highScore;
    private GUIStyle style = new GUIStyle();
    bool gameHasEnded = false;
    private int coins = 0;
    public int coinsCollected = 0;
    public GameObject gameOverOverlay = null;
    public GameObject winOverlay = null;
    public AudioSource loseSound;
    public AudioSource coinSound;
    public AudioSource winSound;

    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").Length;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        startTime = Time.time;
    }

    public void EndGame(bool win)
    {
        if (gameHasEnded == false)
        {
            if (!win)
            {
                gameHasEnded = true;
                loseSound.Play();
                gameOverOverlay.SetActive(true);
            }
            else
            {
                scoreTime = (float)Math.Round(Time.time - startTime, 2);
                winSound.Play();
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    GameObject enemy = enemies[i];
                    Destroy(enemy);
                }
                gameHasEnded = true;
                if (highScore == 0 || scoreTime < highScore)
                {
                    PlayerPrefs.SetFloat("HighScore", scoreTime);
                    winOverlay.GetComponent<Text>().text = "You win!\nYour time was: " + scoreTime.ToString() + "s (New High Score!)\nR - Restart\nEsc - Menu";

                }
                else
                {
                    winOverlay.GetComponent<Text>().text = "You win!\nYour time was: " + scoreTime.ToString() + "s\nR - Restart\nEsc - Menu";
                }
                winOverlay.SetActive(true);
            }
           
        }

    }

    void Update()
    {
        if (gameHasEnded == true && Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (GameObject.FindGameObjectWithTag("Coin") == null)
        {
            EndGame(true);
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }

    private void OnGUI()
    {
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Coins: " + coinsCollected + "/" + coins, style);
        if (highScore == 0)
            GUI.Label(new Rect(10, 70, 100, 20), "High score: -", style);
        else
            GUI.Label(new Rect(10, 70, 100, 20), "High score: " + highScore + "s", style);
    }

    public void CoinCollected()
    {
        coinSound.Play();
        coinsCollected++;
    }

}
