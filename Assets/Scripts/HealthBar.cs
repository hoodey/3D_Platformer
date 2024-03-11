using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    [SerializeField] PlayerStats stats;
    [SerializeField] Image bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = stats.CurrentHealth / stats.MaxHealth;

        if (stats.CurrentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
