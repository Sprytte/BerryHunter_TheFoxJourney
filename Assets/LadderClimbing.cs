using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 2f;
    public Sprite foxClimb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            constant.onLadder = true;
            anim.enabled = false;
            sr.sprite = foxClimb;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            constant.onLadder = false;
            rb.gravityScale = 1;
            rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(constant.onLadder)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            float input_x = Input.GetAxisRaw("Horizontal");
            float input_y = Input.GetAxisRaw("Vertical");

            if (input_x == 0 && input_y == 0)
                anim.enabled = false;
            else
            {
                anim.enabled = true;
                rb.velocity = new Vector2(input_x * speed, input_y * speed);
                anim.SetInteger("direction", 3);

            }
        }
    }
}
