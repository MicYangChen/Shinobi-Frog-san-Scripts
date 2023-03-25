using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex; // The index of the level that this button unlocks.
    private Button button;
    private Text buttonText;

    // Start is called before the first frame update
    private void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();

        // Check if the level has been unlocked.
        int maxLevel = PlayerPrefs.GetInt("MaxLevel", 3);
        if (levelIndex > maxLevel)
        {
            // Disable the button if the level is not unlocked.
            button.interactable = false;
            buttonText.text = "Locked";
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
