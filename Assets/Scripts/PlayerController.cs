using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string GroundedAnimationVar;
    public string SlideAnimationVar;

    bool isGrounded = false;
    public float jumpForce;
    public float fallForce;
    bool doubleJump = false;
    public Transform groundChecker;
    public float groundRadius;
    public LayerMask whatIsGround;

    Rigidbody2D rigBody;
    Animator anim;
    Vector3 initPos;

    private void Awake()
    {
        this.rigBody = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
    }

    private void Start()
    {
        initPos = transform.position;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, whatIsGround);
        anim.SetBool(GroundedAnimationVar, isGrounded);

        if(transform.position.x < initPos.x)
        {
            rigBody.velocity = new Vector2(1f, rigBody.velocity.y);
        }
        else
            rigBody.velocity = new Vector2(0, rigBody.velocity.y);

    }

    private void Update()
    {
        //Sliding (bazrameet!)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<AudioManager>().playSlideSFX();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool(SlideAnimationVar, true);
            //Change collider size!! ==> Done in Animation :P
        }
        else
        {
            anim.SetBool(SlideAnimationVar, false);
        }

        //Jumping
        if ((isGrounded || doubleJump) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
                doubleJump = true;
                FindObjectOfType<AudioManager>().playJumpSFX();
            }
            else if (doubleJump)
            {
                rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
                doubleJump = false;
                FindObjectOfType<AudioManager>().playJumpSFX();
            }
        }

        //Falling
        if (rigBody.velocity.y < 0)
        {
            rigBody.velocity = new Vector2(rigBody.velocity.x, rigBody.velocity.y - (jumpForce * fallForce));
        }
    }

}
