using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestAttemptMenu : MonoBehaviour
{
    public Text level1BestAttemptT;
    public Text level2BestAttemptT;
    public Text level3BestAttemptT;
    public Text level4BestAttemptT;
    public Text level5BestAttemptT;
    public Text level6BestAttemptT;
    public Text level7BestAttemptT;
    public Text level8BestAttemptT;
    public Text level9BestAttemptT;
    public Text level10BestAttemptT;

    // Start is called before the first frame update
    void Start()
    {
        int level1BestAttempt = PlayerPrefs.GetInt("Level 1_BestAttempt", 0);
        level1BestAttemptT.text = level1BestAttempt + " / 3";

        int level2BestAttempt = PlayerPrefs.GetInt("Level 2_BestAttempt", 0);
        level2BestAttemptT.text = level2BestAttempt + " / 3";

        int level3BestAttempt = PlayerPrefs.GetInt("Level 3_BestAttempt", 0);
        level3BestAttemptT.text = level3BestAttempt + " / 3";

        int level4BestAttempt = PlayerPrefs.GetInt("Level 4_BestAttempt", 0);
        level4BestAttemptT.text = level4BestAttempt + " / 3";

        int level5BestAttempt = PlayerPrefs.GetInt("Level 5_BestAttempt", 0);
        level5BestAttemptT.text = level5BestAttempt + " / 3";

        int level6BestAttempt = PlayerPrefs.GetInt("Level 6_BestAttempt", 0);
        level6BestAttemptT.text = level6BestAttempt + " / 3";

        int level7BestAttempt = PlayerPrefs.GetInt("Level 7_BestAttempt", 0);
        level7BestAttemptT.text = level7BestAttempt + " / 3";
    }
}
