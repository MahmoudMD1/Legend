using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PlayerStats[] playerStats;

    public int currentBitCoins;
    public bool gameMenuOpened,dialogBoxOpened,shopOpened;
   
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) { Destroy(this.gameObject); } else { instance = this; }
        DontDestroyOnLoad(gameObject);
       playerStats =FindObjectsOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameMenuOpened || dialogBoxOpened || shopOpened) 
        {
            PlayerController.instance.deactivateMovement = true;
        }
        else
        {
            PlayerController.instance.deactivateMovement = false;
        }
        
            
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }
}
