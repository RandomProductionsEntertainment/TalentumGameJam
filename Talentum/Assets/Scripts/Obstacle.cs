using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    bool touched = false;

    public bool Touched
    {
        get
        {
            return touched;
        }
        set
        {
            touched = value;
        }
    }

    void disableDamage()
    {
        Touched = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
            Invoke("disableDamage", 0.1f);
       /* if (coll.gameObject.CompareTag("Player") && gameObject.transform.Find("Bottom").GetComponent<Collider2D>().tag == "Bottom")
        {
            Debug.Log("BOTTOM");
        }*/
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
