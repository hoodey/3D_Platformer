using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            //EndGame(); Need to do something at this point
        }
    }

    public static float GetTimeRemaining()
    {
        float timeRemaining = 60f - timeLeft;
        return timeRemaining;
    }

}
