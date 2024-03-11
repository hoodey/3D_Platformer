using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] float speed = 4f;
    [SerializeField] float groundCheckDistance = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask environmentOnly;
    [SerializeField] LayerMask trapOnly;
    [SerializeField] float runningSpeed = 10f;
    [SerializeField] float iFrameTimer = 4f;

    //Fields
    //float playerAlpha = 255f;
    Rigidbody rb;
    bool onGround = false;
    bool onTrap = false;
    Transform cam;
    float fmi; //forward movement input = fmi 
    float rmi; //right movement input = rmi
    public bool hurt = false; //damaged state

    //[SerializeField] UnityEvent OnJump //This is for creating an on jump event to trigger like a particle animation
    //UnityAction OnJumpA

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Conditional to track whether we are on ground (by sending a raycast into the floor)
        onGround = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, environmentOnly));
        //Conditional to check if we've landed on spike trap
        onTrap = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, trapOnly));


        //Create movement controls based on input from the left/right axis, and forward/back axis
        fmi = Input.GetAxis("Vertical");
        rmi = Input.GetAxis("Horizontal");

        //Jump logic
        if (Input.GetButtonDown("Jump") && (onGround || onTrap))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        if (!onGround && !onTrap)
        {
            anim.SetBool("onGround", false);
        }
        else if (onGround || onTrap)
        {
            anim.SetBool("onGround", true);
        }

        //Running logic
        if (Input.GetButton("Shift"))
        {
            speed = runningSpeed;
            anim.SetBool("isRunning", true);
        }
        else
        {
            speed = 4f;
            anim.SetBool("isRunning", false);
        }

        if (hurt)
        {
            iFrameTimer -= 1f*Time.deltaTime;
            //playerAlpha = 150f;
        }

        if (iFrameTimer <= 0f)
        {
            hurt = false;
            iFrameTimer = 4f;
            //playerAlpha = 255f;
        }

    }

    //Fixed Update for physics based updates
    private void FixedUpdate()
    {
        //Vector3's for different object's transform data
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        //This code will keep our vertical at 0 for our cam because we only want to face our character left/right and forward/back, not up/down
        camForward.y = 0;
        camForward.Normalize();
        camRight.y = 0;
        camRight.Normalize();
        //Create a vector3 that depends on the direction the camera is facing
        Vector3 forwardRelative = fmi * camForward;
        Vector3 rightRelative = rmi * camRight;

        //Create a vector3 that controls what direction our character travels, multiply that direction by speed (magnitude)
        Vector3 movementVector = (forwardRelative + rightRelative).normalized * speed;

        //Sets our animations transform according to movementVector
        if (movementVector != Vector3.zero)
            anim.transform.forward = movementVector;
        //match our y vector direction to our y velocity
        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;
        

        //This sets the speed variable to the magnitude of movement in order to trigger walking/running anim
        anim.SetFloat("speed", movementVector.magnitude);
        
    }
}
