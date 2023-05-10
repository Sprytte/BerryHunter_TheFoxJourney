using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isSnow = false;
    private bool wallHit = false;
    private float jumpForce = 15f;

    public float speed = 10f;
    public float jumpAmount = 10;
    public GameObject endCanvas;

    private void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
        wallHit = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isJumping = false;
        if (collision.tag.Equals("Snow"))
        {
            isSnow = true;
        }
        if (collision.tag.Equals("Berry"))
        {
            endCanvas.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
            wallHit = true;
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
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.Log(hit.transform.position);*/
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

       /* if (hit.transform.tag.Equals("Floor"))
        {*/
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) &!isJumping)
            {
                if (isSnow)
                {
                    jumpForce = 15f;
                    InvokeRepeating("CalculateJumpForceSnow", 0f, 0.1f);
                }
            else
                InvokeRepeating("CalculateJumpForce", 0f, 0.1f);
            }

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) && !isJumping)
            {
                CancelInvoke();
                if (isSnow)
                {
                    if (jumpForce > 25f)
                        jumpForce = 25f;
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    if (jumpForce > 35f)
                        jumpForce = 35f;
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //use raycast
                }
                jumpForce = 15f;
                isSnow = false;
            }
        //}

    }

    public void CalculateJumpForce()
    {
        jumpForce += 5;
    }
    public void CalculateJumpForceSnow()
    {
        jumpForce += 3;
    }
}
