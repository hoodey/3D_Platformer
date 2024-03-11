using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] TMP_Text statsText;
    [SerializeField] PlayerStats stats;
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "VictoryScreen")
        {
            statsText.text = "You collected all the coins in " + TimerLogic.GetTimeRemaining().ToString() + " seconds!";
        }
        else if (currentScene.name == "GameOver")
        {
            statsText.text = "You collected " + stats.CoinsCollected.ToString() + " coins out of " + (stats.CoinsCollected + stats.CoinsLeft).ToString() + "!"; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }


}
