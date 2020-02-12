using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool IsJump = false;
    public string axis;
    public string jumpCtrl;
    public float moveSpeed;
    public float jump;

    private Rigidbody2D rb;
    private Animator anim;
    private float move;
    private Vector3 localScale;
    private bool facingRight;
    private string IsMove = "IsMove";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis(axis);
        anim.SetBool(IsMove, false);
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Is Not paused
        if (GameController.isPaused == false)
        {
            // Jump
            if (IsJump == false)
            {
                anim.SetBool("IsJump", false);
            }
            if (Input.GetButtonDown(jumpCtrl) && IsJump == false)
            {
                IsJump = true;
                rb.AddForce(Vector2.up * jump);
                anim.SetBool("IsJump", true);
            }

            // Move
            if (Input.GetAxis(axis) < 0)
            {
                anim.SetBool(IsMove, true);
                facingRight = false;
            }
            if (Input.GetAxis(axis) > 0)
            {
                anim.SetBool(IsMove, true);
                facingRight = true;
            }

            flip(facingRight);

            // Start Play
            if (Input.GetButtonDown(axis) || Input.GetButtonDown(jumpCtrl))
            {
                GameController.StartPlay = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
    }

    private void flip(bool fc)
    {
        if ((fc && (localScale.x < 0)) || (!fc && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
