using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public bool gameOver;
    public GameObject gameOverPanel;


    public void OverScreen()
    {
      gameOverPanel.SetActive(true);
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
      //check for no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
       {
            Invoke("OverScreen", 1);
         
       }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");

    }
}

