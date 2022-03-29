using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Creating a reference and link to the controller so that both scripts can communicate
    public CharacterController2D controller;
    //This gets the player movement along the horizontal axis
    float horizontalMovement = 0f;
    //Creating and setting player movement speed
    public float runSpeed = 40f;
    //Creating jump bool to check if the player is jumping already or not
    bool jump = false;
    //Creating a secondary bool for crouching
    bool crouch = false;

    // Update within movement scripts is used to get player input 
    void Update()
    {
     horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Conducts check for player jump
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        //Conducts check for player crouch
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        //If the player presses the crouch button again they will be stood back up
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    //We used fixed update to then apply those inputs
    private void FixedUpdate()
    {
        //Controls how the player moves and behaves
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        //This will reset jump to be false in order to stop the player jumping infintly
        jump = false;
    }
}

