using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    
    public static Inventory instance;
    private List<ItemsManager> itemsList;

    public bool itemAlreadyInInventory;
    // Start is called before the first frame update
    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        itemsList = new List<ItemsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItems(ItemsManager item)
    {
       
        if (item.isStackAble)
        {
            bool itemAlreadyInInventory = false;
            foreach (ItemsManager itemsInInventory in itemsList)
            {
                if (itemsInInventory.itemName == item.itemName)
                {
                    itemsInInventory.amount += item.amount;
                    itemAlreadyInInventory = true;
                    


                }
                
               
            }
            if (!itemAlreadyInInventory)
            {
                itemsList.Add(item);
            }
        }
        else 
        {
            itemsList.Add(item);
        }
    }
    public void RemoveItems(ItemsManager item)
    {
        if (item.isStackAble)
        {
            ItemsManager inventoryItem=null;
            foreach (ItemsManager itemsInInventory in itemsList)
            {
                if (itemsInInventory.itemName == item.itemName)
                {
                    itemsInInventory.amount--;
                    inventoryItem = itemsInInventory;
                }
            }
            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemsList.Remove(inventoryItem);
            }
        }
        else itemsList.Remove(item);
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

}
