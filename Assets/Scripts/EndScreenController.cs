using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] TMP_Text statsText;

    // Start is called before the first frame update
    void Start()
    {
        statsText.text = "You collected all the coins in " + TimerLogic.GetTimeRemaining().ToString() + " seconds!";
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
