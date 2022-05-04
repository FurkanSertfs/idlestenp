using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    public float maxSpeed, stamina, durability;
    public CharacterType characterType;
    public Text maxSpeedText, staminaText, durabilityText,CharacterName;
    public Image maxSpeedBar, staminaBar, durabilityBar,characterImage;
    public OwnedCharacters ownedCharacters;
    void Start()
    {


        durability = characterType.durability;
        maxSpeed = characterType.maxspeed;
        stamina = characterType.stamina;
     
    }
    public void Update()
    {
        maxSpeedBar.fillAmount = maxSpeed / characterType.maxValue;
        staminaBar.fillAmount = stamina / characterType.maxValue;
        durabilityBar.fillAmount = durability / characterType.maxValue;
        CharacterName.text = characterType.CharacterName;
        characterImage.sprite = characterType.characterImage;
        maxSpeedText.text = maxSpeed.ToString();
        staminaText.text = stamina.ToString();
        durabilityText.text = durability.ToString();

    }
    public void Equip()
    {
        ownedCharacters.upgradeMenu.character.characterType = characterType;
        ownedCharacters.stores.SetActive(true);
        ownedCharacters.upgradeMenu.transform.GetChild(0).gameObject.SetActive(true);
        ownedCharacters.gameObject.SetActive(false);
        ownedCharacters.market.MarketMenu("store");
        characterType.isEquipped = true;
        if (ownedCharacters.upgradeMenu.tutorial != null)
        {
            ownedCharacters.upgradeMenu.tutorial.LoadMainLevel();
        }
    }



}
