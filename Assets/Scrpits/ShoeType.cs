using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ShoeType : ScriptableObject
{

    public float efficiency, comfort, luck;
    public string shoeRarity, shoeType, shoeSpeed;
    public Sprite shoeImage;
    public Color32 color;
    public bool isSold,isEquipped;
    public int price,maxValue;
}

