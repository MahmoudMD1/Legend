using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    
    public enum ItemType { Item,Weapon,Armor}
    public ItemType itemType;

    public string itemName, itemDescription;

    public int valueInCoins;

    public Sprite itemImage;


    public enum AffectType { HP,Mana}

    public int ammountOfAffect;

    public AffectType affectType;

    public int weaponDexterity;
    public int armorDefence;

    public bool isStackAble;
    public int amount;
    
    public static ItemsManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void UseItem(int CharacterToUse)
    {
        PlayerStats selectedCharater = GameManager.instance.GetPlayerStats()[CharacterToUse];
        if (itemType == ItemType.Item)
        {
            if (affectType == AffectType.HP)
            {
                selectedCharater.AddHP(ammountOfAffect);
            }
            else if (affectType == AffectType.Mana)
            {
                selectedCharater.AddMana(ammountOfAffect);
            }
        }
        else if (itemType == ItemType.Weapon)
        {
            if (selectedCharater.equipedWeaponName != "")
            {
                Inventory.instance.AddItems(selectedCharater.equipedWeapon);
            }
            selectedCharater.EquipedWeapon(this);
        }
        else if(itemType == ItemType.Armor)
        {
            if(selectedCharater.equipedArmorName !="")
            {
                Inventory.instance.AddItems(selectedCharater.equipedArmor);
            }
            selectedCharater.EquipedArmor(this);
        }

        
            
        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("U'Ve Picked Up"+itemName);
            Inventory.instance.AddItems(this);
            gameObject.SetActive(false);
        }
        
    }
}
