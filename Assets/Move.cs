using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool wallHit = false;
    private float jumpForce = 15f;

    public float speed = 10f;
    public float jumpAmount = 10;

    private void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Wall"))
            wallHit= true;
        if (!collision.gameObject.tag.Equals("Wall"))
            wallHit = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        if (input_x > 0 && !wallHit) //right
        {
            anim.SetInteger("direction", 1);
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
        }
        if (input_x < 0 && !wallHit) //left
        {
            anim.SetInteger("direction", 2);
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
        }

        if (input_x == 0 && input_y == 0)
            anim.SetInteger("direction", 0);


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))&& !isJumping)
        {
            InvokeRepeating("CalculateJumpForce", 0f, 0.2f);
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) && !isJumping)
        {
            CancelInvoke();
            if (jumpForce > 35f)
                jumpForce = 35f;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //use raycast
            jumpForce= 15f;
        }

        //rb.MovePosition(rb.position + new Vector2(input_x, 0) * Time.deltaTime * speed);
    }

    public void CalculateJumpForce()
    {
        jumpForce += 10;
    }
}
