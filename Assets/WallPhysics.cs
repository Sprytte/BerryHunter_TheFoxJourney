using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPhysics : MonoBehaviour
{
    public float velocityX = 8f;
    public float velocityY = 4f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Fox") && !constant.hit)
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(player.velocity.x);
            Vector3 vel = player.velocity;
            Debug.Log(vel.x);
            /*if (vel.x > 0)
                player.AddForce(new Vector2(10, 15), ForceMode2D.Impulse);
            if (vel.x < 0)*/
                //player.AddForce(new Vector2(-10, 15), ForceMode2D.Impulse);
            player.velocity = player.velocity * new Vector3(-velocityX, 1, 1);
            player.AddForce(new Vector2(0, vel.y * velocityY), ForceMode2D.Impulse);
        }
        else
            constant.hit = false;
    }
}
