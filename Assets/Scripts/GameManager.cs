using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject GameOverPanel;
    public static int score = 0;
 
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void IncreaseScore()
    {
        score++;
        RefreshUI();
    }
    public void RefreshUI()
    {
        scoreText.text = "Score - " + score;
    }
}
