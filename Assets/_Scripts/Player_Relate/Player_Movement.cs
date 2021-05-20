using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float Jumpforce = 1;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJumping;

    public float hangTime = 0.2f;
    private float hangCounter;

    public float jumpBufferLenght = 0.1f;
    private float jumpBufferCount;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Movement Left and right
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
    }

    void Update()
    {
        //Check ground system
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //Tap jump for normal jump
        if(jumpBufferCount >= 0 && hangCounter > 0f) 
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            _rigidbody.velocity = Vector2.up * Jumpforce;

            jumpBufferCount = 0;
        }

        //Hold jump for higher jump
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(JumpTimeCounter > 0)
            {
                _rigidbody.velocity = Vector2.up * Jumpforce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        //check if jumping
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        //Jump hangtime
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        //jump buffer manager
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

    }

}
