using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level is complete!");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SoundManager.Instance.Play(Sounds.LevelComplete);
        }
    }
}
