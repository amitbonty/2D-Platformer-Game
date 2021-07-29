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
        SceneManager.LoadScene(SceneName);
    }
}
