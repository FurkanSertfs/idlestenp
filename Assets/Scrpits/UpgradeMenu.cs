using UnityEngine;
using UnityEngine.UI;


public class UpgradeMenu : MonoBehaviour
{

    public Text upgradeMenuName, efficiencyText, newefficiencyText, comfortText, newcomfortText, luckText, newluckText, maxSpeedText, newmaxSpeedText, staminaText, 
        newstaminaText, durabilityText, newdurabilityText,levelCostText;
    public Image shoeImage, characterImage,shoeFrame,characterFrame;
    public Sprite emtyShoeImage, emtyCharacterImage;
    public CharacterType characterType;
    public ShoeType shoeType;
    public Market market;
    public Character character;
    public Button characterButton,shoeButton;
    public GameManager gameManager;
    public Tutorial tutorial;
    



    void Update()
    {

      if(character!=null)
        {
          
            characterType = character.characterType;
            shoeType = character.shoeType;
            upgradeMenuName.text = "Runner Level " + character.level.ToString();


            if (character.shoeType != null)
            {
              
                
                efficiencyText.text = character.effenefficiency.ToString("F1");
                comfortText.text = character.comfort.ToString("F1");
                luckText.text = character.luck.ToString("F1");
                shoeImage.sprite = character.shoeType.shoeImage;
                shoeButton.enabled = false;
                shoeImage.sprite = shoeType.shoeImage;
                shoeFrame.color = shoeType.color;
                newefficiencyText.text = "+0.5";
                newcomfortText.text = "+0.5";
                newluckText.text = "+0.5";
            }
            else
            {
                efficiencyText.text = "0.0";
                newefficiencyText.text = "";
                comfortText.text = "0.0";
                newcomfortText.text = "";
                luckText.text = "0.0";
                newluckText.text = "";
                shoeButton.enabled = enabled;
                shoeImage.sprite = emtyShoeImage;
                shoeFrame.color = Color.white;
            }

            if (characterType != null)
            {
                characterButton.enabled = false;
                durabilityText.text = character.durability.ToString("F1");
                maxSpeedText.text = character.maxspeed.ToString("F1");
                staminaText.text = character.stamina.ToString("F1");
                characterImage.sprite = characterType.characterImage;
                characterFrame.color = characterType.color;
                newdurabilityText.text = "+0.5";
                newmaxSpeedText.text = "+0.5";
                newstaminaText.text = "+0.5";
            }
            else
            {
                characterButton.enabled = true;
                durabilityText.text = "0.0";
                newdurabilityText.text = "";
                maxSpeedText.text = "0.0";
                newmaxSpeedText.text = "";
                staminaText.text = "0.0";
                newstaminaText.text = "";
                characterImage.sprite = emtyCharacterImage;
                characterFrame.color = Color.white;

            }
            if (character.shoeType != null && characterType != null)
            {
                levelCostText.text = character.levelCost.ToString("F1") + "$";
            }
            else
            {
                levelCostText.text = "";
            }
        }


     


    }
    public void LevelUp()
    {
         if (character.shoeType != null && characterType != null)
            {
                if (gameManager.money >= character.levelCost)
                {
                gameManager.money -= character.levelCost;
                character.level++;

                }
        }

       
    }

}
