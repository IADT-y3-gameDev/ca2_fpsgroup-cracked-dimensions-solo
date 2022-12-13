using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //variables go here
    public float speed = 5;
    
    public float jumpPower = 4;
    Rigidbody rb;
    CapsuleCollider col;

    Animator animator;
    int isRunningHash;
    int isSprintingHash;
    int isJumpingHash;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isSprintingHash = Animator.StringToHash("isSprinting");
        isJumpingHash = Animator.StringToHash("isJumping");
 
    }

    // Update is called once per frame
    void Update()
    {

        //get input values from controllers
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;
        
        //translate our character
        transform.Translate(Horizontal, 0, Vertical);
        
        //test if character can jump
        //Debug.Log("hi:"+ isGrounded());

        bool isSprinting = animator.GetBool (isSprintingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool forwardPressed = Input.GetKey("w");
        bool sprintPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");

        //if w is pressed set the isRunning parameter to true
        if(!isRunning && forwardPressed){
            animator.SetBool(isRunningHash, true);
        }
        //set to false
        if(isRunning && !forwardPressed){
            animator.SetBool(isRunningHash, false);
        }

        if(!isSprinting && (forwardPressed && sprintPressed)){
            animator.SetBool(isSprintingHash, true);
        }

        if(isSprinting && (!forwardPressed || !sprintPressed)){
            animator.SetBool(isSprintingHash, false);
        }

        if(jumpPressed){
            animator.SetBool(isJumpingHash, true);
        }

        if(!jumpPressed){
            animator.SetBool(isJumpingHash, false);
        }

        if (isGrounded() && Input.GetButtonDown("Jump")) 
        {
            //add upward force to the rigidbody
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        } 

        if (Input.GetKeyDown("escape"))
        {
                Cursor.lockState = CursorLockMode.None;
        }
    }
    
    private bool isGrounded()
    {
        //Test that we are grounded by drawing an invisible raycast line
        //if this hits a solid object we are grounded
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.2f);
    }

}

