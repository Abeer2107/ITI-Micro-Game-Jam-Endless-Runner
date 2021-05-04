using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] string GroundedAnimationVar;
    [SerializeField] string SlideAnimationVar;
    [Header("Player Settings")]
    [SerializeField] float jumpForce;
    [SerializeField] float fallForce;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool canDoubleJump = true;
    [Header("SFX")]
    [SerializeField] AudioClip slideClip;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip hitClip;

    Rigidbody2D rigBody;
    Animator animator;
    AudioSource audioSource;
    Vector3 initPos;
    bool isGrounded = false;
    bool doubleJump = false;

    private void OnEnable()
    {
        ScrollingObject.PlayerHit += TakeHit;
    }
    private void OnDisable()
    {
        ScrollingObject.PlayerHit -= TakeHit;
    }

    private void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        initPos = transform.position;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, whatIsGround);
        if(animator) animator.SetBool(GroundedAnimationVar, isGrounded);

        //Return to initial position if pushed back
        if(transform.position.x < initPos.x)
        {
            rigBody.velocity = new Vector2(1f, rigBody.velocity.y);
        }
        else { 
            rigBody.velocity = new Vector2(0, rigBody.velocity.y);
        }
    }

    private void Update()
    {
        //Sliding
        if (Input.GetKeyDown(KeyCode.DownArrow) && audioSource)
        {
            audioSource.clip = slideClip;
            audioSource.Play();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
           if(animator) animator.SetBool(SlideAnimationVar, true);
        }
        else
        {
           if(animator) animator.SetBool(SlideAnimationVar, false);
        }

        //Jumping
        if ((isGrounded || doubleJump) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
                if(canDoubleJump) doubleJump = true;
            }
            else if (doubleJump)
            {
                rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
                doubleJump = false;
            }
            if (audioSource)
            {
                audioSource.clip = jumpClip;
                audioSource.Play();
            }
        }

        //Falling
        if (rigBody.velocity.y < 0)
        {
            rigBody.velocity = new Vector2(rigBody.velocity.x, rigBody.velocity.y - (jumpForce * fallForce));
        }
    }

    void TakeHit()
    {
        if (audioSource)
        {
            audioSource.clip = hitClip;
            audioSource.Play();
        }
    }

}
