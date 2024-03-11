using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class iFramePanelDisplay : MonoBehaviour
{
    [SerializeField] UnityEvent hurt;
    [SerializeField] UnityEvent notHurt;
    public Image image;
    GameObject player;
    PlayerController p;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("CharacterParent");
        p = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (p.hurt)
            hurt.Invoke();
        else if (p.hurt == false)
            notHurt.Invoke();
    }

    public void hurtDisplay()
    {
         image.color = new Color(image.color.r, image.color.g, image.color.b, .25f);
    }

    public void notHurtDisplay()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}
