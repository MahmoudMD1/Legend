using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    public string playerName;

    public Sprite characterImage;

    public int maxLevel=50;

    public int playerLevel=1;
    public int currentXP;

    public int[] xpForNextLevel;

    public int baseLevelXP;

    public int maxHP =100;
    public int currentHP ;
    

    public int maxMana =30;
    public int currentMana;

    public int dexterity;
    public int defence;

    public string equipedArmorName;
    public string equipedWeaponName;

    public int weaponPower;
    public int armorDefence;

    public ItemsManager equipedWeapon, equipedArmor;

    public static PlayerStats instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        xpForNextLevel = new int[maxLevel];
        
        for (int i = 1; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = (int)((0.02f*i * i * i ) + (3.06f * i * i) + (105.6f*i )) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L)) { ADDXP(100); }
    }
    public void ADDXP(int amountOfXP)
    {
        currentXP += amountOfXP; 

        if (currentXP > xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;


            maxHP = (int) (maxHP*1.18);
            currentHP = maxHP;

            maxMana = (int)(maxMana * 1.06);
            currentMana =maxMana;


            if (playerLevel % 2 == 0)
            {
                dexterity++;
            }
            else 
            { 
                defence++; 
            }

        }
    }
    public void AddMana(int amountOfMana)
    {
        if (currentMana != maxMana) 
        {
            currentMana +=amountOfMana;
            if (currentMana >= maxMana)
            {
                currentMana = maxMana;
            }

        }
    }
    public void AddHP(int amountOfHp)
    {
        if(currentHP != maxHP)
        {
            currentHP +=amountOfHp;
            if(currentHP >= maxHP)
            {
                currentHP = maxHP;
            }
        }
    }
    public void EquipedWeapon(ItemsManager weaponToEquip)
    {

        
        equipedWeapon = weaponToEquip;
        equipedWeaponName = equipedWeapon.itemName;
        weaponPower = equipedWeapon.weaponDexterity;


    }
    public void EquipedArmor(ItemsManager armorToEquip)
    {
        equipedArmor = armorToEquip;
        equipedArmorName = equipedArmor.itemName;
        armorDefence = equipedArmor.armorDefence;
    }


}
