using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int apples = 0;
    private int bestAttempt = 0;
    private string levelName;

    [SerializeField] private Text applesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        Debug.Log("Level name: " + levelName);
        bestAttempt = PlayerPrefs.GetInt(levelName + "_BestAttempt", 0);
        // Update the apples text
        applesText.text = "Apples: " + apples;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "Apples: " + apples + " / 3";

            if (apples > bestAttempt) // saves the apples to max count
            {
                bestAttempt = apples;
                PlayerPrefs.SetInt(levelName + "_BestAttempt", bestAttempt);
            }
        }
    }
}
