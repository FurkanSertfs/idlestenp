using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Store : MonoBehaviour
{

    public GameObject store, newStore;
    public GameManager gameManager;
    public float price, transformY = -1275;
    public int storeCount=1;
  

    void Start()
    {
        NewStore();





    }
  public void NewStore()
    {

        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y + 500);
        newStore = Instantiate(store, transform.position, transform.rotation, transform);
        newStore.GetComponent<Character>().gameManager = gameManager;
        newStore.GetComponent<Character>().storeCount = storeCount;
        newStore.GetComponent<Character>().store = GetComponent<Store>();
        transformY -= 475;
        newStore.GetComponent<Character>().transformY = transformY;
       
        storeCount++;
     
    }



}
