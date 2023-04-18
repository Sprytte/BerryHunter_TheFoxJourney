using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public float speed = 10f;

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
        }
        if (input_x < 0) //left
            anim.SetInteger("direction", 2);

        if (input_x == 0 && input_y == 0)
            anim.SetInteger("direction", 0);

        rb.MovePosition(rb.position + new Vector2(input_x, input_y) * Time.deltaTime * speed);
    }
}
