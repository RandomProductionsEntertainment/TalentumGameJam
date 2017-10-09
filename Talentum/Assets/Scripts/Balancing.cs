using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancing : MonoBehaviour {
    int angle = 0;
    bool right = true;
    [SerializeField]
    Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {
        
       // rb2D.AddForce(Vector2.right*3);
	}
	
	// Update is called once per frame
	void Update () {
        if (angle < 45 && right)
        {
            Debug.Log(angle);
            angle += 1;
            transform.Rotate(new Vector3(0, 0, 1), 2*Time.deltaTime);
        }
        if (angle >= 45)
            right = false;
        if(angle> -45 && !right)
        {
            angle -= 1;
            transform.Rotate(new Vector3(0, 0, 1), -2 * Time.deltaTime);
        }
        if (angle <= -45)
            right = true;


    }

    }
