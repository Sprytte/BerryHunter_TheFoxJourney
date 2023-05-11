using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool onLadder = false;
    public float speed = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            onLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            onLadder = false;
            rb.gravityScale = 1;
            rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onLadder)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            float input_x = Input.GetAxisRaw("Horizontal");
            float input_y = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(input_x * speed, input_y * speed);
        }
    }
}
