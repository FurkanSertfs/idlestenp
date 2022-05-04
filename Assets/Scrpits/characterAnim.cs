using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterAnim : MonoBehaviour
{
    public Character character;
    public Sprite deneme1, deneme2;
    public bool start = false;
    public Image image;

    void Start()
    {
        
    }

    void Update()
    {
        if (!start&&character.characterType!=null)
        {
            image.sprite = character.characterType.characterImage;
        }
        if (character.characterType != null && character.shoeType != null)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
    public void ImageFirst()
    {
        start = true;
        if (character.characterType != false)
            image.sprite = character.characterType.charcterWalk;
        else
            image.sprite = character.emptyCharcterImage;
    }
    public void ImageSecond()
    {
        if (character.characterType != false)
         image.sprite = character.characterType.characterWalk2;
        else
            image.sprite = character.emptyCharcterImage;
    }

}
