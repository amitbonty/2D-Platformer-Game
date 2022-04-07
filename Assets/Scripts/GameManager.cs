using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    GameObject GameOverPanel;
    public int score = 0;
 
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
