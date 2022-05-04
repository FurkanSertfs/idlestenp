using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class marketCharacter : MonoBehaviour
{
    public CharacterType characterType;
    public Image chracterImage,characterRarity;
    public Text priceText,rarityText;
    public Button button, buybutton;


    void Awake()
    {
        chracterImage.sprite = characterType.characterImage;
        characterRarity.color = characterType.color;
        priceText.text = characterType.price.ToString();
        rarityText.text = characterType.rarity;





    }

    void Update()
    {
        if (characterType.isSold)
        {
            priceText.text = "";
            buybutton.GetComponentInChildren<Text>().text = "Owned";
            button.enabled = false;
            buybutton.enabled = false;
        }
        
    }
}
