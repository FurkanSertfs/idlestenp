using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShoeSlot : MonoBehaviour
{
    public float efficiency, comfort, luck;
    public ShoeType shoeType;
    public Text efficiencyText, comfortText, luckText;
    public Image efficiencyBar, comfortBar, luckBar, shoeImage;
    public OwnedShoe ownedShoe;
    void Start()
    {

        efficiency = shoeType.efficiency;
        comfort = shoeType.comfort;
        luck = shoeType.luck;
    }

    // Update is called once per frame
    void Update()
    {
        efficiencyBar.fillAmount = efficiency / shoeType.maxValue;
        comfortBar.fillAmount = comfort / shoeType.maxValue;
        luckBar.fillAmount = luck / shoeType.maxValue;
       
        shoeImage.sprite = shoeType.shoeImage;
        efficiencyText.text = efficiency.ToString();
        comfortText.text = comfort.ToString();
        luckText.text = luck.ToString();

    }

    public void Equip()
    {
        ownedShoe.upgradeMenu.character.shoeType = shoeType;
        ownedShoe.stores.SetActive(true);
        ownedShoe.upgradeMenu.transform.GetChild(0).gameObject.SetActive(true);
        ownedShoe.market.MarketMenu("store");
        ownedShoe.gameObject.SetActive(false);
        shoeType.isEquipped = true;
        if (ownedShoe.upgradeMenu.tutorial != null)
        {
            ownedShoe.upgradeMenu.tutorial.ownedCharacter();
        }
        



    }

}
