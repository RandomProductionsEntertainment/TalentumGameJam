using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsSpawner : MonoBehaviour {


    [SerializeField]
    GameObject[] spawner;
    [SerializeField]
    GameObject[] whatPrefabIs;
    
	// Use this for initialization
	void Start () {
        spawnProps();
	}

    private void spawnProps()
    {
        
        Instantiate(whatPrefabIs[UnityEngine.Random.Range(0, whatPrefabIs.Length - 1)], spawner[UnityEngine.Random.Range(0, spawner.Length - 1)].transform.position, Quaternion.identity);
        Invoke("spawnProps", 1f);
    }

    // Update is called once per frame
    void Update () {
		

	}
}
