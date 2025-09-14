using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;
    


    private Vector3 bottomLeft;
    private Vector3 topRight;
    private float sprentSpeed= 2f;

    public static PlayerController instance;

    public string responseArea;

    public bool deactivateMovement =false;




    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance!=this) {Destroy(this.gameObject);}else{instance = this;}
        //playerRigidbody=GetComponent<Rigidbody2D>();



        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal"); /// movmement input in right and left
        float verticalInput = Input.GetAxisRaw("Vertical"); // up and down
        playerRigidbody.linearVelocity = new Vector2 (horizontalInput, verticalInput) *moveSpeed; // movement in 2D

        if (deactivateMovement || UIController.instance.menu.activeInHierarchy)
        {
            
            playerRigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            playerRigidbody.linearVelocity = new Vector2(horizontalInput, verticalInput) * moveSpeed; // movement in 2D}
            
        }

        playerAnimator.SetFloat("Movement X",playerRigidbody.linearVelocity.x); //setting the value of x in animation to player's x
        playerAnimator.SetFloat("Movement Y",playerRigidbody.linearVelocity.y); //setting the value of y in animation to player's y

       
        if (horizontalInput == 1 || horizontalInput == -1 || verticalInput == 1 || verticalInput == -1)
        {
            if (!deactivateMovement)
            {
                playerAnimator.SetFloat("Last X", horizontalInput);
                playerAnimator.SetFloat("Last Y", verticalInput);
            }

        }
        // making the postion between the top right and bottom left which is the cordinates of the image so player cant get out of screen 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), Mathf.Clamp(transform.position.z, bottomLeft.z, topRight.z));

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            playerRigidbody.linearVelocity *= sprentSpeed;
        }


    }

    public void SetLimits(Vector3 BottomEdge,Vector3 TopEdge ) 
    { 
        bottomLeft = BottomEdge;
        topRight = TopEdge;
    }



}
