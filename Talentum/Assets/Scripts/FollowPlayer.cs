using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    float speed = 10f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + move.x * speed * Time.deltaTime, gameObject.transform.position.y + move.y * speed * Time.deltaTime,-gameObject.transform.position.z);

    }
}
