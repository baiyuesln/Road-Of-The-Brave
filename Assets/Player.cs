using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]public float moveSpeed;
    [SerializeField]private float jumpForce;
    private float xInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput*moveSpeed,rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving",isMoving);
    }
}
