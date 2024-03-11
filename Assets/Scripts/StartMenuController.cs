using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    //Set stats to be able to reset them on menu start up
    [SerializeField] PlayerStats stats;
    const int NUMBER_OF_COINS_IN_SCENE = 10;

    // Start is called before the first frame update
    void Start()
    {
        //Set all of our defaults for the game on main menu load
        stats.MaxHealth = 10f;
        stats.CurrentHealth = 10f;
        stats.CoinsCollected = 0;
        stats.CoinsLeft = NUMBER_OF_COINS_IN_SCENE;
        TimerLogic.ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void quit()
    {
        Application.Quit();
    }
}
