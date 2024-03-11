using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] AudioSource soundEffect;
    bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.CoinsLeft <= 0)
            AllCoinsCollected();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
        {
            stats.CoinsCollected += 1;
            stats.CoinsLeft -= 1;
            soundEffect.Play();
            Object.Destroy(this.gameObject, .8f);
            collected = true;
        }
    }

    void AllCoinsCollected()
    {
        SceneManager.LoadScene("VictoryScreen");
    }
}
