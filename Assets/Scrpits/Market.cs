using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
   
    public Text shoeRarityText,shoePrice,efficiencyValuText, luckValuText, comfortValuText,
                characterRarityText,characterPrice,staminaValueText,durabilityValuText,maxSpeedValueText, moneyText;
    public Image shoeRarity, shoeTypeF, shoeSpeed,characterRarity, shoeImage, characterImage, playImage, characterMarketImage, 
        shoeMarketImage, efficiencyBar, luckBar, comfortBar, staminaBar, durabilityBar, maxSpeedBar;
   
    public ScrollRect scrollRect;
    public GameObject showDetails, shoeContainer, characterContainer,showCharacterDetails,ownedCharacter,ownedShoe,stores;
    public Button buyButtonShoe, buyButtonCharacter;
    public GameManager gm;
    public CharacterType characterType;
    public ShoeType shoeType;
    public Sprite playActive, playDeactive, chracterMarketActive, chracterMarketDeactive, shoeMarketActive, shoeMarketDeactive;



     void Update()
    {
        moneyText.text = gm.money.ToString("F1");

    }


    public void ShowDeatils(ShoeType type)
    {
        showDetails.SetActive(true);
        buyButtonShoe.onClick.AddListener(delegate() {gm.BuyShoe (type);});
        shoeImage.sprite = type.shoeImage;
        shoeRarityText.text = type.shoeRarity;
       if (!type.isSold)
        {

            shoePrice.text = type.price.ToString("F1");
           
        }
        else
        {
            shoePrice.text = "";
            buyButtonShoe.GetComponentInChildren<Text>().text = "Owned";
        }
       

        efficiencyValuText.text = type.efficiency.ToString("F1");
        luckValuText.text = type.luck.ToString("F1");
        comfortValuText.text = type.comfort.ToString("F1");
        shoeRarity.color = type.color;
        efficiencyBar.fillAmount = type.maxValue / type.efficiency;
        comfortBar.fillAmount = type.maxValue / type.comfort;
        luckBar.fillAmount = type.maxValue / type.luck;

    }

    public void ShowDeatils(CharacterType type)
    {
        // buyButton.onClick.AddListener(delegate () { gm.BuyShoe(type); });
        buyButtonCharacter.onClick.AddListener(delegate () { gm.BuyCharacter(type); });
        if (!type.isSold)
        {

            characterPrice.text = type.price.ToString("F1");

        }
        else
        {
            characterPrice.text = "";
            buyButtonCharacter.GetComponentInChildren<Text>().text = "Owned";
        }
        showCharacterDetails.SetActive(true);
        characterRarityText.text = type.rarity;
        staminaValueText.text = type.stamina.ToString("F1");
        durabilityValuText.text = type.durability.ToString("F1");
        maxSpeedValueText.text = type.maxspeed.ToString("F1");
        characterImage.sprite = type.characterImage;
        characterRarity.color = type.color;
        maxSpeedBar.fillAmount = type.maxspeed / type.maxValue;
        staminaBar.fillAmount = type.stamina / type.maxValue;
        durabilityBar.fillAmount = type.durability / type.maxValue;




    }

    public void BackDeatil()
    {
        showDetails.SetActive(false);
        showCharacterDetails.SetActive(false);
    }

    
    public void MarketMenu(string menuName)
    {
        if (menuName.Equals("shoe"))
        {
            scrollRect.content = shoeContainer.GetComponent<RectTransform>();
            shoeContainer.SetActive(true);
            characterContainer.SetActive(false);
            ownedCharacter.SetActive(false);
            ownedShoe.SetActive(false);
            stores.SetActive(false);
            shoeMarketImage.sprite = shoeMarketActive;
            characterMarketImage.sprite = chracterMarketDeactive;
            playImage.sprite = playDeactive;



        }
      else  if (menuName.Equals("character"))
        {
            scrollRect.content = characterContainer.GetComponent<RectTransform>();
            shoeContainer.SetActive(false);
            characterContainer.SetActive(true);
            ownedCharacter.SetActive(false);
            ownedShoe.SetActive(false);
            stores.SetActive(false);
            shoeMarketImage.sprite = shoeMarketDeactive;
            characterMarketImage.sprite = chracterMarketActive;
            playImage.sprite = playDeactive;
        }
        else if (menuName.Equals("store"))
        {
            scrollRect.content = stores.GetComponent<RectTransform>();
            shoeContainer.SetActive(false);
            characterContainer.SetActive(false);
            ownedCharacter.SetActive(false);
            ownedShoe.SetActive(false);
            stores.SetActive(true);
            shoeMarketImage.sprite = shoeMarketDeactive;
            characterMarketImage.sprite = chracterMarketDeactive;
            playImage.sprite = playActive;

        }

        else if (menuName.Equals("ownedCharacter"))
        {
            scrollRect.content = ownedCharacter.GetComponent<RectTransform>();
            shoeContainer.SetActive(false);
            characterContainer.SetActive(false);
            ownedCharacter.SetActive(true);
            ownedShoe.SetActive(false);
            stores.SetActive(false);
            shoeMarketImage.sprite = shoeMarketDeactive;
            characterMarketImage.sprite = chracterMarketDeactive;
            playImage.sprite = playDeactive;

        }
        else if (menuName.Equals("ownedShoe"))
        {
            scrollRect.content = ownedShoe.GetComponent<RectTransform>();
            shoeContainer.SetActive(false);
            characterContainer.SetActive(false);
            ownedCharacter.SetActive(false);
            ownedShoe.SetActive(true);
            stores.SetActive(false);
            shoeMarketImage.sprite = shoeMarketDeactive;
            characterMarketImage.sprite = chracterMarketDeactive;
            playImage.sprite = playDeactive;



        }



    }

    }
