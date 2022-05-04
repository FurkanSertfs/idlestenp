using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedShoe : MonoBehaviour
{
    public GameObject shoeSlot, newSlot, stores;
    public List<GameObject> slots;
    public GameManager gameManager;
    public ShoeType shoeType;
    public Character character;
    public Market market;
    public UpgradeMenu upgradeMenu;

    private void OnEnable()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Destroy(slots[i]);

        }
        for (int i = 0; i < gameManager.ownedShoes.Count; i++)
        {
            if (!gameManager.ownedShoes[i].isEquipped)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y + 325);
                newSlot = Instantiate(shoeSlot, transform.position, transform.rotation, transform);
                slots.Add(newSlot);
                newSlot.GetComponent<ShoeSlot>().shoeType = gameManager.ownedShoes[i];
                newSlot.GetComponent<ShoeSlot>().ownedShoe = GetComponent<OwnedShoe>();

            }

        }
    }

}
