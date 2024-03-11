using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapLogic : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] AudioSource soundEffect;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject;
        PlayerController p = player.GetComponent<PlayerController>();
        if (p.hurt == false)
        {
            if (stats.CurrentHealth > 0)
            {
                stats.CurrentHealth -= 1;
            }
            soundEffect.Play();
            p.hurt = true;
        }
    }


}
