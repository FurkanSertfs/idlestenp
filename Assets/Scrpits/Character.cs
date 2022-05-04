using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public CharacterType characterType;
    public Text priceText,earnText;
    public ShoeType shoeType;
    public GameObject character;
    public float stamina, durability, maxspeed,effenefficiency, comfort, luck,storePrice, transformY,coolDown, coolDownInterval=4,energy,levelCost,earnCount;
    public int rarityCharacter, rarityShoe,level,storeCount;
    public Transform startP, finishP;
    public GameManager gameManager;
    public Image storeFrame, characterImage,energyBar;
    public Sprite emptyCharcterImage,emtyShoeImage;
    public bool isOpen=false;
    public Animator animator;
    public Button button;
    public Store store;
    int randomNumber;
    UpgradeMenu upgradeMenu;
    bool state=true,shoeLoad=false,characterLoad=false,stamineReflesh=false,couldownLoaded=false;
  

    void Start()
    {
        

        gameManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        storePrice = (((Mathf.Pow(storeCount, 3.4f) + 5 + (Mathf.Sin(storeCount)))));
        upgradeMenu = gameManager.upgradeMenu;
      

    }

  
    void Update()
    {

      
        GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x, transformY, GetComponent<RectTransform>().localPosition.z);
        levelCost = (((Mathf.Pow(level, 1.4f) + 1 + (Mathf.Sin(level)))));
     


        priceText.text = storePrice.ToString("F1")+"$";
        if (characterLoad && shoeLoad)
        {
            earnCount = 1 + (effenefficiency / 5);
            earnText.text = earnCount.ToString("F1") + "$";
        }

        if (isOpen  && shoeType != null&&!shoeLoad)
        {

            shoeLoad = true;
            effenefficiency = shoeType.efficiency;
            comfort = shoeType.comfort;
            luck = shoeType.luck;
           
        }
        if (shoeLoad)
        {

            effenefficiency = shoeType.efficiency+level/2.0f;
            comfort = shoeType.comfort+level/2.0f;
            luck = shoeType.luck+level/2.0f;

        }


        if (isOpen && characterType!=null&&!characterLoad)
            {

            characterLoad = true;
            durability = characterType.durability;
            maxspeed = characterType.maxspeed;
            stamina = characterType.stamina;
            storeFrame.color = characterType.color;
          

        }
        if (characterLoad)
        {
            stamina = characterType.stamina + level / 2.0f;
            energyBar.fillAmount = energy / (stamina);
            durability = characterType.durability + level / 2.0f;
            maxspeed = characterType.maxspeed+level/2.0f;
         

        }



        if (isOpen && characterType != null && shoeType != null&& energy - (1 - (durability / 100)) > 0)
        {

            if (character.transform.position.x <= finishP.transform.position.x && state)
            {

                character.transform.position = new Vector3(character.transform.position.x + Time.deltaTime * maxspeed*15, character.transform.position.y, character.transform.position.z);
            }

            else if (character.transform.position.x >= finishP.transform.position.x)
            {
                state = false;
                character.transform.localScale = new Vector3(-1, character.transform.localScale.y, character.transform.localScale.z);


            }


            if (character.transform.position.x >= startP.transform.position.x && !state)
            {

                character.transform.position = new Vector3(character.transform.position.x - Time.deltaTime * maxspeed*15, character.transform.position.y, character.transform.position.z);
            }

            else if (character.transform.position.x <= startP.transform.position.x)
            {
                state = true;
                EarnMeachic();

                character.transform.localScale = new Vector3(1, character.transform.localScale.y, character.transform.localScale.z);


            }
        }
        if (!stamineReflesh)
        {
            coolDown = Time.time;
        }
        if (isOpen && characterType != null && shoeType != null && energy - (1 - (durability / 100)) < 0)
        {
            stamineReflesh = true;
            if (!couldownLoaded)
            {
                coolDown += coolDownInterval - (comfort / 25);
                Debug.Log(coolDownInterval - (comfort / 25));
                couldownLoaded = true;
            }
           
            if (coolDown < Time.time)
            {

                energy = stamina;
                couldownLoaded = false;
                stamineReflesh = false;

            }

        }







    }
    public void DisableAnim()
    {
        GetComponent<Animator>().enabled = false;
    }



    public void BuyStore()
    {
        if(gameManager.money > storePrice&& !isOpen)
        {

            gameManager.money -= storePrice;
            isOpen = true;
            animator.enabled = true;

            button.onClick.AddListener(UpgradeMenu);

            store.NewStore();
        }
        


    }

    public void UpgradeMenu()
    {
        upgradeMenu.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        upgradeMenu.character = GetComponent<Character>();



    }






    public void EarnMeachic()
    {
        if(energy - (1-(durability/100))>0)
        {
            gameManager.money += earnCount;
            energy -= (1 - (durability / 100));
            randomNumber = Random.Range(0, 100);
            if (randomNumber <= luck)
            gameManager.specialMoney++;

        }

     
        

    }




    


}
