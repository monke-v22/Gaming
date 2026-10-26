using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode LeftArrow;
    public KeyCode RightArrow;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    void Start()
    {
anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
         anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
         anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
         anim.SetBool("Grounded", grounded);
  grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        if (Input.GetKey(RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
