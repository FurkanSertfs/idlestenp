using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterType : ScriptableObject
{

    public float stamina, durability, maxspeed;
    public int price,maxValue;
    public string rarity, CharacterName;
    public Sprite characterImage,charcterWalk,characterWalk2;
    public Color32 color;
    public bool isSold, isEquipped;


}
