using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]public float moveSpeed;
    [SerializeField]private float jumpForce;
    private float xInput;
    private int facingDir = 1;
    private bool facingRight = true;
    [Header("碰撞信息")]
    [SerializeField]private float groudCheckDistance;
    [SerializeField]private LayerMask whatIsGround;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Movement();
        CheckInput();
        CollisionChecks();
        Debug.Log(isGrounded);
        FlipController();
        AnimatorControllers();
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groudCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorControllers()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
    }

    private void Flip()
    {
        facingDir = facingDir*-1;
        facingRight = !facingRight;
        transform.Rotate(0,180,0); 
    }
    private void FlipController()
    {
        if(rb.velocity.x>0&&!facingRight)
        {
            Flip();
        }
        else if(rb.velocity.x<0&&facingRight)
        {
            Flip();
        }
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x,transform.position.y-groudCheckDistance));
    }
}
