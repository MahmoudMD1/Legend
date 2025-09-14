using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemButton : MonoBehaviour
{
    public ItemsManager itemOnButton;
    public void ShowStats()
    {

         
        if (UIController.instance.menu.activeInHierarchy) 
        { 
             // Set the text property of itemNameText to the string from ItemsManager
            UIController.instance.itemNameValue.text = itemOnButton.itemName;
            UIController.instance.itemDescriptioValue.text = itemOnButton.itemDescription; //mking the text to clicked text


            UIController.instance.activeItem=itemOnButton; //set the clicked item to valurable 
        }
        if (ShopManager.instance.shopMenu.activeInHierarchy) 
        {

            if (ShopManager.instance.buyPanel.activeInHierarchy)
            {
                ShopManager.instance.SelectedBuyitem(itemOnButton);
            }
            else if (ShopManager.instance.sellPanel.activeInHierarchy)
            {
                ShopManager.instance.SelectedSellItem(itemOnButton);
            }
        }

    }
    
}

