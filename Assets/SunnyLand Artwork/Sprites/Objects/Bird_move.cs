using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bird_move : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;

    public float speed = 5f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
      // transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if(anim.GetInteger("direction") == 1)
            anim.SetInteger("direction", 2);
        else
            anim.SetInteger("direction", 1);
        speed = -speed;
    }
}
