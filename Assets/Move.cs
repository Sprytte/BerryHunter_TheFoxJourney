using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isJumping = false;

    public float speed = 10f;
    public float jumpAmount = 10;

    void OnTriggerStay(Collider other)
    {
        isJumping = false;
    }

    void OnTriggerExit(Collider other)
    {
        isJumping = true;
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

        if (input_x > 0) //right
        {
            anim.SetInteger("direction", 1);
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
        }
        if (input_x < 0) //left
        {
            anim.SetInteger("direction", 2);
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
        }

        if (input_x == 0 && input_y == 0)
            anim.SetInteger("direction", 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpAmount), ForceMode2D.Impulse); //use raycast
        }

        //rb.MovePosition(rb.position + new Vector2(input_x, 0) * Time.deltaTime * speed);
    }
}
