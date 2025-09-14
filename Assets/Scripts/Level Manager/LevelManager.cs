using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Tilemap Tilemap;


    private Vector3 bottomLeft;
    private Vector3 topRight;
    // Start is called before the first frame update
    void Start()
    {
        // is the cordinates of the image so player cant get out of screen
        bottomLeft = Tilemap.localBounds.min + new Vector3(.5f, 1f, 0f);
        topRight = Tilemap.localBounds.max + new Vector3(-.5f, -1f, 0f);


        PlayerController.instance.SetLimits(bottomLeft, topRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
