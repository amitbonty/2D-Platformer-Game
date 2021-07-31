using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance{get{ return instance; }}
    public string[] Levels;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetLevelStatus((Levels[0]), LevelStatus.Unlocked);
        SetLevelStatus((Levels[1]), LevelStatus.Unlocked);
        SetLevelStatus((Levels[2]), LevelStatus.Unlocked);
     
    }
    public void MarkCurrentLevelComplete()
    {
        var scene = SceneManager.GetActiveScene();
        SetLevelStatus(scene.name, LevelStatus.Completed);
        var currentSceneIndex = Array.FindIndex(Levels, Levels => Levels == scene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }

    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting level : " + level + " Status: " + levelStatus);
    }
}
