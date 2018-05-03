using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Building
{
    public bool barracksSelected;

	// Use this for initialization
	void Start ()
    {
        buildings.Add(this);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            barracksSelected = true;
        }
    }
}