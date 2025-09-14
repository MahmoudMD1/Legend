using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    private bool canOpenShop;
    [SerializeField] List<ItemsManager> sKItemsForSale;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canOpenShop && Input.GetButtonDown("Fire1") &&  !PlayerController.instance.deactivateMovement && !ShopManager.instance.shopMenu.activeInHierarchy)
        {

            //ShopManager.instance.UpdateShopItems(Transform itemSlotContainerParents, List <ItemsManager> itemsToLookThrough);
            ShopManager.instance.itemForSale = sKItemsForSale;
            ShopManager.instance.OpenShopMenu();
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" )
        {
            canOpenShop = true;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpenShop = false;
            
        }

    }
}
