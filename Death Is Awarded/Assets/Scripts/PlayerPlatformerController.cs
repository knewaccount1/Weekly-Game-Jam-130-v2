using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MonoBehaviour
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float jumpFallFactor = 0.5f;
    private Rigidbody2D rb;
    private AudioManager audioManager;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool shortJump;
    private float airTime;
    public float playLongJump;


    //Improved Jump (JumpBuffering)
    float fJumpPressedRemember = 0;
    [SerializeField] float fJumpPressedRememberTime = 0.2f;

    //(Coyote time)
    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;
    // Use this for initialization

    //ground raycast
    public float groundCastDistance;
    bool grounded;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {

        Physics2D.queriesStartInColliders = false;
      
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.y, groundCastDistance);
        Debug.Log("grounded bool: " + grounded + "hit: " + hit);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        fGroundedRemember -= Time.deltaTime;
        if (grounded)
        {
            fGroundedRemember = fGroundedRememberTime;
        }

        fJumpPressedRemember -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))    //JUMP BUFFERING
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }

        if ((fJumpPressedRemember > 0) && grounded) //JUMP BUFFERING
        {
            fJumpPressedRemember = 0;
            rb.velocity = Vector2.up * jumpTakeOffSpeed;
            audioManager.PlayAudio("Jump Short");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = rb.velocity * new Vector2 (1,jumpFallFactor);
            }
        }

        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0)) //COYOTE TIME
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb.velocity = rb.velocity * new Vector2 (1,jumpTakeOffSpeed);
        }


        //manual flip sprite

        if (move.x < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1f;
            transform.localScale = theScale;

        }
        if (move.x > 0)
        {

            Vector3 theScale = transform.localScale;
            theScale.x = 1f;
            transform.localScale = theScale;

        }


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        rb.velocity = new Vector2(move.x * maxSpeed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * transform.localScale.y * groundCastDistance);
    }
}



//    protected override void ComputeVelocity()
//    {
//        Vector2 move = Vector2.zero;

//        move.x = Input.GetAxis("Horizontal");

//        fGroundedRemember -= Time.deltaTime;
//        if (grounded)
//        {
//            fGroundedRemember = fGroundedRememberTime;
//        }

//        fJumpPressedRemember -= Time.deltaTime;

//        if (Input.GetButtonDown("Jump"))    //JUMP BUFFERING
//        {
//            fJumpPressedRemember = fJumpPressedRememberTime;

//        }

//        if((fJumpPressedRemember>0) && grounded) //JUMP BUFFERING
//        {
//            fJumpPressedRemember = 0;
//            velocity.y = jumpTakeOffSpeed;
//            audioManager.PlayAudio("Jump Short");
//        }
//        else if (Input.GetButtonUp("Jump"))
//        {
//            if (velocity.y > 0)
//            {
//                velocity.y = velocity.y * jumpFallFactor;
//            }
//        }

//        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0)) //COYOTE TIME
//        {
//            fJumpPressedRemember = 0;
//            fGroundedRemember = 0;
//            velocity.y = jumpTakeOffSpeed;
//        }


//        //manual flip sprite

//        if (move.x < 0)
//        {
//            Vector3 theScale = transform.localScale;
//            theScale.x = -1f;
//            transform.localScale = theScale;

//        }
//        if (move.x > 0)
//        {

//            Vector3 theScale = transform.localScale;
//            theScale.x = 1f;
//            transform.localScale = theScale;

//        }


//        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
//        if (flipSprite)
//        {
//            spriteRenderer.flipX = !spriteRenderer.flipX;
//        }

//        //animator.SetBool("grounded", grounded);
//        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

//        targetVelocity = move * maxSpeed;
//    }
//}
