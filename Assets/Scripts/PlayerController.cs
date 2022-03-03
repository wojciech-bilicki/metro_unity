using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool _isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        _isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && _isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        anim.SetBool("isOnGround", _isOnGround);

        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));




    }
}
