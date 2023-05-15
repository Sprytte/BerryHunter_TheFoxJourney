using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float zAxis;
    public float zAxis2 = -5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < 0)
            transform.position = new Vector3(0, 0, zAxis);
        else
            transform.position = new Vector3(0, player.position.y) + new Vector3(0, 1, zAxis2);

    }
}
