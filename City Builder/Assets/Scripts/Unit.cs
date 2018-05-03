using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Unit : MonoBehaviour
{
    public bool moving;
    public Vector3 endpos;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position,endpos + new Vector3(0,0,10), .3f);
            if(transform.position == endpos)
            {
                moving = false;
            }
        }
    }
}
