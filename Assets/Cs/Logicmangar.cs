using UnityEngine;
// using UnityEditor.UI;
using UnityEngine.UI;
// using Unity.VisualScripting;
// using System;
using UnityEngine.SceneManagement;


public class Logicmangar : MonoBehaviour
{   
    public Text scoreText;
    public GameObject GameOver;
    public Text MainMenu;
    public bool MenuActive = true;
    public int playerScore = 0;
    public int multiplyer = 1;
    public float pipeSpeed;


    [ContextMenu("Increes Score")]
    public void addScore(int score)
    {
        playerScore += score;
        scoreText.text = $"Score: {playerScore.ToString()}";
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        MainMenu.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        MenuActive = false;

    }

    public void GameOverScreen()
    {
        GameOver.SetActive(true);
    }
}
