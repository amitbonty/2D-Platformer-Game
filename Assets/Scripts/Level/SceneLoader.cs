using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
     Button button;
    [SerializeField]
     string SceneName;
     
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
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(SceneName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(SceneName);
                break;
        }
      
    }
}
