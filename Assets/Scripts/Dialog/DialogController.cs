using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DialogController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI dialogText, nameText;
    public GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogScentance;

    [SerializeField] int currentScentance;
    private bool dialogJustStarted;

    public static DialogController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        dialogText.text = dialogScentance[currentScentance]; //making the texet of dialog to the array sentances
        


    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!dialogJustStarted)
                {
                    currentScentance++;

                    if (currentScentance >= dialogScentance.Length)
                    {
                        dialogBox.SetActive(false);
                        //nameBox.SetActive(false);
                        //currentScentance = 0; fixed by if condition
                        PlayerController.instance.deactivateMovement=false;

                    }
                    else
                    {
                        CheckForName();
                        dialogText.text = dialogScentance[currentScentance];
                        

                    }
                }
                else 
                {
                    dialogJustStarted = false; 
                }
            }
        }

    }

    public void CheckForName() 
    {
        if (dialogScentance[currentScentance].StartsWith("#"))
        {
            nameText.text = dialogScentance[currentScentance].Replace("#", "");
            currentScentance++;
        }
    }
    public void ActivateDialog(string[] newSentenceToUse)
    {
        dialogScentance = newSentenceToUse;
        currentScentance = 0;
        CheckForName();
        dialogText.text =dialogScentance[currentScentance];
        dialogBox.SetActive(true);
        dialogJustStarted = true;
        PlayerController.instance.deactivateMovement=true; // to make player cant move during the conversiton or u can comment it it will dissaper when healer is gone from the screen 
    }
    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }
}
