using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedCharacters : MonoBehaviour
{
    public GameObject charSlot,newSlot,stores;
    public List<GameObject> slots;
    public GameManager gameManager;
    public CharacterType characterType;
    public Character character;
    public Market market;
    public UpgradeMenu upgradeMenu;
    
   
    private void OnEnable()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Destroy(slots[i]);

        }
        for (int i = 0; i < gameManager.ownedCharacter.Count; i++)
        {
            if (!gameManager.ownedCharacter[i].isEquipped)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y + 325);
                newSlot = Instantiate(charSlot, transform.position, transform.rotation, transform);
                slots.Add(newSlot);
                newSlot.GetComponent<CharacterSlot>().characterType = gameManager.ownedCharacter[i];
                newSlot.GetComponent<CharacterSlot>().ownedCharacters = GetComponent<OwnedCharacters>();

            }

        }
    }
}
