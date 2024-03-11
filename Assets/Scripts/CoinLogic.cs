using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        stats.CoinsCollected += 1;
        stats.CoinsLeft -= 1;
        soundEffect.Play();
        Object.Destroy(this.gameObject,.8f);
    }
}
