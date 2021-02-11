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
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetButtonDown("Jump")) 
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            _rigidbody.velocity = Vector2.up * Jumpforce;
        }

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

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        //Movement Jumping
        //if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        //{
        //    _rigidbody.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
        //}


    }

}
