using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;
    public int nextSceneLoad;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f); // Delays 1 second before calling CompleteLevel().
        }
    }

    private void CompleteLevel()
    {
        int maxLevel = PlayerPrefs.GetInt("MaxLevel"); // Max level index is 9.
        
        if (nextSceneLoad > maxLevel)
        {
            PlayerPrefs.SetInt("MaxLevel", nextSceneLoad);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(nextSceneLoad);
    }

}
