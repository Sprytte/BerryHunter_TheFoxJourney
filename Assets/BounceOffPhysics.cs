using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffPhysics : MonoBehaviour
{
    public float velocityY = 4f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Fox"))
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 vel = player.velocity;
            Debug.Log(vel.y);
            player.AddForce(new Vector2(0, vel.y * velocityY), ForceMode2D.Impulse);
        }
    }
}
