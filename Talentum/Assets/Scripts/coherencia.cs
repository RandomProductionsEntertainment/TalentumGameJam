﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coherencia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Obstacle"))
        {

        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
