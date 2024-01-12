using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.SetInt("MaxLevel", 9);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
    }
}
