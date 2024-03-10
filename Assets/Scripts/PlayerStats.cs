using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public float MaxHealth = 10;
    public float CurrentHealth = 10;
    public float CoinsCollected = 0;
    public float CoinsLeft = 10;
}
