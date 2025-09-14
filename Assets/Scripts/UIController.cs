using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] Image fadingImage;

    

    public GameObject menu;

    private PlayerStats[] playerStats;

    [SerializeField] TextMeshProUGUI[] nameText, hptext, manaText, lvlText, xpText;
    [SerializeField] Slider[] sliders;
    [SerializeField] Image[] charaterImages;
    [SerializeField] GameObject[] charaterPanel , statsButtons;

    [SerializeField] TextMeshProUGUI statName, statHp, statMana, statDex, statDef,statEquipedWeapon,StatEquipedArmor;
    [SerializeField] TextMeshProUGUI statWeaponPower,statArmorDefance;
    [SerializeField] Image statPlayerImage;

    [SerializeField] GameObject itemsSlotContainer;
    [SerializeField] Transform itemsSlotContainerParent;

    public TextMeshProUGUI itemNameValue,itemDescriptioValue;

    public ItemsManager activeItem;
    public TextMeshProUGUI itemAmountText;

    [SerializeField] GameObject characterChoicePanal;
    [SerializeField] TextMeshProUGUI[] ItemsCharterChoiceName;


    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.M)) 
        {
            UpdateItemsInventory();
            if (menu.activeInHierarchy)
            {
                
                menu.SetActive(false);
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
            }
        }
    }
    public void UpdateStats() 
    {
        playerStats = GameManager.instance.GetPlayerStats();
        
        
        for (int i = 0; i < playerStats.Length; i++)
        {
            charaterImages[i].sprite = playerStats[i].characterImage;
            charaterPanel[i].SetActive(true);
            nameText[i].text = " "+playerStats[i].name;
            hptext[i].text = "HP: " +playerStats[i].currentHP +"/" +playerStats[i].maxHP;
            xpText[i].text = "next lvl xp : " + playerStats[i].currentXP +"/" + playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            lvlText[i].text = "Lvl: " +playerStats[i].playerLevel +"/" +playerStats[i].maxLevel;
            manaText[i].text = "Mana: " +playerStats[i].currentMana +"/" +playerStats[i].maxMana;
            sliders[i].maxValue = playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            sliders[i].value = playerStats[i].currentXP;
            
            
            

           
        }
    }
    public void FadeImage()
    {
        fadingImage.GetComponent<Animator>().SetTrigger("Start Fade");
    }
    public void StatsMenu()
    {
        for (int i = 0; i < playerStats.Length; i++)
        {
            statsButtons[i].SetActive(true);
            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;
            
        }
        StatsMenuUpdate(0);
    }
    public void StatsMenuUpdate(int playerSelectedNumber)
    {
        PlayerStats playerSelected = playerStats[playerSelectedNumber];

        statName.text = playerSelected.playerName;

        statHp.text = playerSelected.currentHP.ToString() + "/" +playerSelected.maxHP;

        statMana.text = playerSelected.currentMana.ToString() + "/" + playerSelected.maxMana;

        statDex.text = playerSelected.dexterity.ToString() ;

        statDef.text = playerSelected.defence.ToString();

        statPlayerImage.sprite = playerSelected.characterImage;


        statEquipedWeapon.text =playerSelected.equipedWeaponName;
        StatEquipedArmor.text =playerSelected.equipedArmorName;

        statWeaponPower.text =playerSelected.weaponPower.ToString();
        statArmorDefance.text =playerSelected.armorDefence.ToString();
    }
    public void UpdateItemsInventory()
    {

        foreach(Transform itemSlot in itemsSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach(ItemsManager item in Inventory.instance.GetItemsList())
        {
            
            RectTransform itemSlot =Instantiate(itemsSlotContainer,itemsSlotContainerParent).GetComponent<RectTransform>();
            
            Image itemImage =itemSlot.Find("Item Image").GetComponent<Image>();
            itemImage.sprite =item.itemImage;
            
            TextMeshProUGUI itemAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>(); // there is an error here its ammout text 

            if (item.amount > 1) { itemAmountText.text = item.amount.ToString(); }
                
            else { itemAmountText.text = "";}

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;
            
        }

        
    }
    public void UseItem(int selectedCharacter) 
    {
        
        activeItem.UseItem(selectedCharacter);
        OpenChracterChoicePanel();
        DiscardItem(); // that should be moved
    }
    public void OpenChracterChoicePanel()
    {
        characterChoicePanal.SetActive(true);
        if (activeItem)
        {
            for (int i = 0; i < playerStats.Length; i++)
            {
                PlayerStats activePlayer = GameManager.instance.GetPlayerStats()[i];
                ItemsCharterChoiceName[i].text = activePlayer.playerName;

                bool activePlayerAvaiable = activePlayer.gameObject.activeInHierarchy;
                ItemsCharterChoiceName[i].transform.parent.gameObject.SetActive(activePlayerAvaiable);

            }
        }
    }
    
   public void CloseChracterChoicePanel()
   {
        characterChoicePanal.SetActive(false);
   }
   

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("See U Later");
    }

    public void DiscardItem()
    {

        Inventory.instance.RemoveItems(activeItem);
        UpdateItemsInventory();
        
    }

}
