using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLogic : MonoBehaviour {
    PlayerController playerController;
    public float zAngleTarget;
    public float secondsToLerp;
    float t;
    float randomDirection;
    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        t = 0;
        InvokeRepeating("ChangeDirection", 2.0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
       // t += Time.deltaTime / secondsToLerp;
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, zAngleTarget, t));
    }

    void ChangeDirection()
    {
        randomDirection = Random.Range(0, 50);
        Debug.Log(randomDirection);
        if(randomDirection < 10)
        {
            int direction = Random.Range(0, 4);
            playerController.ChangeDirection(direction);
        }
    }
}
