using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    private void Awake()
    {
        
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
