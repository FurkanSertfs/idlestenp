using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Tutorial : MonoBehaviour
{

    public GameObject hand1, hand2, hand3, hand4, hand5,hand6,hand7,hand8,hand9,hand10,hand11,characterDetails,shoeDetails,upgradeMenu;
    public Button chracterButton, shoeButton, playButton,openStoreButton;
    public Character character;
    public Animator anim;
    public void ChracterMenu0n()
    {
        GetComponent<Animator>().SetBool("characterMenu", true);
        hand1.SetActive(false);
        hand2.SetActive(true);
    }
    public void Chracter0n()
    {
        GetComponent<Animator>().SetBool("character", true);
      
        hand2.SetActive(false);
        hand3.SetActive(true);
    }
    public void ChracterSold()
    {
        GetComponent<Animator>().SetBool("charactersold", true);
       
        hand3.SetActive(false);
        hand4.SetActive(true);
        characterDetails.SetActive(false);
        chracterButton.enabled = false;
        shoeButton.enabled = true;
    }
    public void ShoeMenu0n()
    {
        GetComponent<Animator>().SetBool("shoeMenu", true);
        hand4.SetActive(false);
        hand2.SetActive(true);
    }


    public void ShoeOn()
    {
        GetComponent<Animator>().SetBool("shoe", true);

        hand2.SetActive(false);
        hand3.SetActive(true);
    }




    public void ShoeSold()
    {
        GetComponent<Animator>().SetBool("shoeSold", true);
        hand3.SetActive(false);
        shoeDetails.SetActive(false);
        chracterButton.enabled = false;
        shoeButton.enabled = false;
        playButton.enabled = true;
        hand6.SetActive(true);
    }
    public void PlayMenu()
    {

        hand6.SetActive(false);
        hand7.SetActive(true);
        GetComponent<Animator>().SetBool("playMenu", true);
        openStoreButton.enabled = true;


    }
    public void openStore()
    {
        character.BuyStore();
        openStoreButton.onClick.AddListener(UpgradeMenu);



    }
    public void UpgradeMenu()
    {
        hand7.SetActive(false);
        hand8.SetActive(true);
        
        GetComponent<Animator>().SetBool("ownedShoe", true);
        

    }
    public void ownedShoe()
    {
        hand8.SetActive(false);
        
    }
    public void ownedCharacter()
    {
        GetComponent<Animator>().SetBool("ownedCharacter", true);
        hand9.SetActive(true);

    }
    public void Closehand9()
    {
        hand9.SetActive(false);

    }
    public void LoadMainLevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(2);
    }

}
