using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    public Button button;
    public string SceneName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    public void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(SceneName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant Play this level until unlocked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(SceneName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(SceneName);
                break;
        }
      
    }
}
