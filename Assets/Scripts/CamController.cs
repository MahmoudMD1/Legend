using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamController : MonoBehaviour
{
    private PlayerController playerTarget;
    CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<PlayerController>(); // asign player target to our player so we dont make it manual
        virtualCamera = GetComponent<CinemachineVirtualCamera>(); // getting the compomant of the Vcam
        virtualCamera.Follow = playerTarget.transform; // making the follow of the cam to be always our player
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
