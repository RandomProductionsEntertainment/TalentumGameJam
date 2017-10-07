using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {

    Rigidbody2D rb2D;
    float speed = 10f;
	// Use this for initialization
	void Start () {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2D.transform.position = new Vector2(rb2D.transform.position.x+move.x*speed*Time.deltaTime, rb2D.transform.position.y+move.y * speed * Time.deltaTime);

    }
}
