using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShoe : MonoBehaviour
{
    public ShoeType shoeType;
    public Image shoeImage, shoeRarity;
    public Text priceText;
    public Button button, buybutton;

    void Awake()
    {
        shoeImage.sprite = shoeType.shoeImage;
        shoeRarity.color = shoeType.color;
        priceText.text = shoeType.price.ToString();

    }

    
    void Update()
    {
        if (shoeType.isSold)
        {
            priceText.text = "";
            buybutton.GetComponentInChildren<Text>().text = "Owned";
            button.enabled = false;
            buybutton.enabled = false;
        }

    }
}
