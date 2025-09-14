using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public GameObject shopMenu ,buyPanel,sellPanel;
    [SerializeField] TextMeshProUGUI currentBitCoinText;

    public List<ItemsManager> itemForSale;

    [SerializeField] Transform  itemSlotBuyContainerParent , itemSlotSellContainerParent;
    [SerializeField] GameObject itemSlotContainer;

    [SerializeField] ItemsManager selectedItem;
    [SerializeField] TextMeshProUGUI buyItemName , buyItemDescription , buyItemValue;
    [SerializeField] TextMeshProUGUI sellItemName, sellItemDescription, sellItemValue;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShopMenu()
    {
        shopMenu.SetActive(true);
        GameManager.instance.shopOpened = true;
        currentBitCoinText.text="BTC: "+GameManager.instance.currentBitCoins;
        buyPanel.SetActive(true);
    }
    public void CloseShopMenu() 
    {
        shopMenu.SetActive(false);
        GameManager.instance.shopOpened = false;

    }
    public void OpenBuyPanal()
    {
        UpdateShopItems(itemSlotBuyContainerParent, itemForSale);
        buyPanel.SetActive(true);
        sellPanel.SetActive(false);
        


    }
    public void OpenSellPanal()
    {
        UpdateShopItems(itemSlotSellContainerParent, Inventory.instance.GetItemsList()); //itemForSale
        buyPanel.SetActive(false);
        sellPanel.SetActive(true);
        
    }
   

    public void UpdateShopItems(Transform itemSlotContainerParent, List<ItemsManager> itemsToLookThrough)
    {

        foreach (Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetItemsList())
        {

            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();

            Image itemImage = itemSlot.Find("Item Image").GetComponent<Image>();
            itemImage.sprite = item.itemImage;

            TextMeshProUGUI itemAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>(); // there is an error here its ammout text 

            if (item.amount > 1) { itemAmountText.text = item.amount.ToString(); }

            else { itemAmountText.text = ""; }

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;

        }
        

    }

    public void SelectedBuyitem(ItemsManager ItemToBuy)
    {
        selectedItem = ItemToBuy;
        buyItemName.text =selectedItem.itemName;
        buyItemDescription.text =selectedItem.itemDescription;
        buyItemValue.text ="Value: "+selectedItem.valueInCoins;
    }
    public void SelectedSellItem (ItemsManager ItemToSell)
    {
        
        selectedItem = ItemToSell;
        sellItemName.text = selectedItem.itemName;
        sellItemDescription.text = selectedItem.itemDescription;
        sellItemValue.text = "Value: " + selectedItem.valueInCoins *.75f;

    }

    internal void UpdateShopItems(Transform transform, object itemSlotContainerParents, bool v)
    {
        throw new NotImplementedException();
    }
}
