using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bird_move : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    public float velocityX = 8f;

    public float speed = 5f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
      // transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(anim.GetInteger("direction") == 1)
            anim.SetInteger("direction", 2);
        else
            anim.SetInteger("direction", 1);
        speed = -speed;

        if (collision.gameObject.name.Equals("Fox"))
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 vel = player.velocity;
            player.velocity = player.velocity * new Vector3(-velocityX, 1, 1);
            if(speed > 0) 
                player.AddForce(new Vector2(-velocityX, 0), ForceMode2D.Impulse);
            else
                player.AddForce(new Vector2(velocityX, 0), ForceMode2D.Impulse);
            constant.hit = true;
        }
    }
}
