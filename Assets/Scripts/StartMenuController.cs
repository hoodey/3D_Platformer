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

    // Start is called before the first frame update
    void Start()
    {
        
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
