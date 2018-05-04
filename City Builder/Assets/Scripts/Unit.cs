using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool moving;
    public Vector3 endpos;
    Rigidbody2D rigid;
    float maxSpeed = 7;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(moving)
        {
            rigid.AddForce(((Vector2)endpos - (Vector2)transform.position).normalized * 200);
            if (rigid.velocity.magnitude > maxSpeed)
            {
                rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
            }
            if(Vector2.Distance(transform.position, endpos)<=.5f)
            {
                moving = false;
                rigid.velocity = Vector2.zero;
            }
        }
    }
}
