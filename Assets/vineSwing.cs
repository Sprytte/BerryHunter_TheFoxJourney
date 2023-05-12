using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineSwing : MonoBehaviour
{
    public Vector3 initialForce;
    public float speed = 2.5f;

    private Transform swingArea;
    private bool swinging = false;
    private bool canSwing = true;
    private Rigidbody2D rb;

    private string vine1 = "";
    private string vine2 = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Vine"))
        {
            if(vine1 == "" || vine1 != collision.gameObject.name)
                vine1= collision.gameObject.name;

            if (vine1 == vine2 && vine1 != "")
                canSwing = false;
            else
                canSwing = true;

            if (canSwing)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x * initialForce.x, 0, 0);
                swinging = true;
                swingArea = collision.transform;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            canSwing = true;
            vine1 = ""; vine2 = "";
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging && canSwing)
        {
            rb.velocity = Vector3.zero;
            transform.position = swingArea.position;

           /* float input_x = Input.GetAxisRaw("Horizontal");
            swingArea.GetComponent<Rigidbody2D>().velocity = new Vector2(input_x * speed, 0);*/

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)))
            {
                vine2 = vine1;
                Debug.Log("Can jump");
                swinging = false;
                canSwing= false;
                rb.velocity =new Vector3(swingArea.GetComponent<Rigidbody2D>().velocity.x, 2f, 0);
            }
        }
    }
}
