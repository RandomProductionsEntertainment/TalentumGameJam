﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsSpawner : MonoBehaviour {


    [SerializeField]
    GameObject[] spawner;
    [SerializeField]
    GameObject[] whatPrefabIs;
    [SerializeField]
    int maxTimeToSpawn = 3;
    
	// Use this for initialization
	void Start () {
        spawnProps();
	}

    private void spawnProps()
    {
        
        Instantiate(whatPrefabIs[UnityEngine.Random.Range(0, whatPrefabIs.Length)], spawner[UnityEngine.Random.Range(0, spawner.Length )].transform.position, Quaternion.identity);
        Invoke("spawnProps",UnityEngine.Random.Range(0, maxTimeToSpawn));
    }

    // Update is called once per frame
    void Update () {
		

	}
}
