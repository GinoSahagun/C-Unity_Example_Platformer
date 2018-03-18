using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCtrl : MonoBehaviour {


    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    [Tooltip("A Non Negative Integer For Higher Movement in the Horizontal")]
    public int SpeedBoost;
    public float JumpSpeed;
    public float delayDoubleJump;
    bool canDoubleJump = false;
    bool isJumping = false;
    public bool isGrounded = true;
    public Transform Feet;
    public float feetRadius;
    public float boxWidth;
    public float boxHeight;
    public LayerMask whatIsGround;
    public Transform LeftBulletSpawn, RightBulletSpawn;
    public GameObject LeftBullet, RightBullet;

    void Start () {
       rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();

	}
	

	void Update () {

        //isGrounded = Physics2D.OverlapCircle(Feet.position, feetRadius, whatIsGround);
        isGrounded = Physics2D.OverlapBox(Feet.position, new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);
        float playerSpeed = Input.GetAxisRaw("Horizontal"); //returns a -1 for left, 1 for right, 0 for stop
        playerSpeed *= SpeedBoost;

        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();

        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Input.GetButtonDown("Fire1"))
            FireBullets();

	}

     void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(Feet.position, feetRadius);
        Gizmos.DrawWireCube(Feet.position, new Vector3(boxWidth, boxHeight));
    }

    //Makes the Player Move Left Or Right
    void MoveHorizontal(float playerSpeed)
    {
       
        if (playerSpeed < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        if (!isJumping)
            anim.SetInteger("State", 1);

        ShowFalling();


    }
    //Makes the Player Jump in the Positive Y Axis
    void Jump()
    {
        if (isGrounded )
        {
            rb.AddForce(new Vector2(0, JumpSpeed));
            anim.SetInteger("State", 2);
            isJumping = true;

            Invoke("EnterDoubleJump", delayDoubleJump);
        }

        if (canDoubleJump && !isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, JumpSpeed));
            anim.SetInteger("State", 2);
            canDoubleJump = false;
        }

    }

    void EnterDoubleJump ()
    {
        canDoubleJump = true;
    }

    void ShowFalling()
    {
        if (rb.velocity.y < 0)
            anim.SetInteger("State", 3);
    }
    
    void FireBullets()
    {
        if (spriteRenderer.flipX)
            Instantiate(LeftBullet, LeftBulletSpawn.position, Quaternion.identity);
        else
            Instantiate(RightBullet, RightBulletSpawn.position, Quaternion.identity);
    }

    //Handle Collision 2D 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJumping = false;
    }
    //Stop the Player From Moving
    void StopMoving ()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!isJumping)
            anim.SetInteger("State", 0);
    }


}
