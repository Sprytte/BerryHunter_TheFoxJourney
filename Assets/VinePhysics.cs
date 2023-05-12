using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinePhysics : MonoBehaviour
{
    public Vector3 initialForce;
    public float speed = 2.5f;

    private Transform player;
    private bool swinging = false;
    private bool canSwing = true;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Fox") && canSwing)
        {
            rb.velocity = initialForce;
            swinging = true;
            player = collision.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging && canSwing)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.position = transform.position;

            /* float input_x = Input.GetAxisRaw("Horizontal");
             swingArea.GetComponent<Rigidbody2D>().velocity = new Vector2(input_x * speed, 0);*/

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)))
            {
                Debug.Log("Can jump");
                swinging = false;
                canSwing = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, 2f, 0);
            }
        }
    }
}
