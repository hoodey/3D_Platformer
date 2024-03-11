using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] TMP_Text counter;
    [SerializeField] TMP_Text remaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Coins Collected: " + stats.CoinsCollected.ToString();
        remaining.text = "Coins Remaining: " + stats.CoinsLeft.ToString();
    }
}
