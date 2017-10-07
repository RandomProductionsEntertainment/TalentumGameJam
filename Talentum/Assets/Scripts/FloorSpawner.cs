using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {

    [SerializeField]
    GameObject floor;

	// Use this for initialization
	void Start () {
        spawn();
	}
	
    void spawn()
    {
        Instantiate(floor, transform.position, Quaternion.identity);
        Invoke("spawn", 1.5f);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
