using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerLogic : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] static float timeLeft = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Time Remaining: " + Mathf.RoundToInt(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft += 60f;
            GameOver();
        }

        if (Input.GetButtonDown("R"))
        {
            Restart();
        }

    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static float GetTimeRemaining()
    {
        float timeRemaining = 60f - timeLeft;
        return timeRemaining;
    }

    void Restart()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public static void ResetTimer()
    {
        timeLeft = 60f;
    }

}
