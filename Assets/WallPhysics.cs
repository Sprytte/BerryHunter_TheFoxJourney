using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(player.velocity.x);
        Vector3 vel = player.velocity;
        Debug.Log(vel.x);
        /*if (vel.x > 0) 
            player.AddForce(new Vector2(10, 15), ForceMode2D.Impulse);
        if (vel.x < 0)*/
        //player.AddForce(new Vector2(-10, 15), ForceMode2D.Impulse);
        player.velocity = player.velocity * new Vector3(-1, 1, 1);
        //player.AddForce(new Vector2(player.velocity.x *-10, 15), ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
