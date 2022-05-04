using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float money,storePrice,specialMoney;
    public List<ShoeType> ownedShoes;
    public List<CharacterType> ownedCharacter;
    public GameObject newStore,store,storesParent;
    public int storeCount;
    public Market market;
    public UpgradeMenu upgradeMenu;
    public List<float> price;


     void Start()
    {
        Screen.SetResolution((int)(Screen.currentResolution.width / 1.25f),(int) (Screen.currentResolution.height / 1.25f),true);
        Application.targetFrameRate = 60;
    }

    public void BuyShoe(ShoeType shoeType)
    {
       
        if(money>= shoeType.price && !shoeType.isSold)
        {
          
            money -= shoeType.price;
            shoeType.isSold = true;
            ownedShoes.Add(shoeType);
            market.buyButtonShoe.GetComponentInChildren<Text>().text = "Owned";
        
        
        }

    }
    public void BuyCharacter(CharacterType characterType)
    {
      
        if (money >= characterType.price && !characterType.isSold)
        {
          

            money -= characterType.price;
            characterType.isSold = true;
            ownedCharacter.Add(characterType);
            market.buyButtonCharacter.GetComponentInChildren<Text>().text = "Owned";
          

        }

    }
    


}
