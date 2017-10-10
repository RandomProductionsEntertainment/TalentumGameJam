using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brujula : MonoBehaviour {

    int angle = 0;
    bool finished = true;
    float timer = 0;
    int changeDir = 0;
    [SerializeField]
    Rigidbody2D rb2D;


    // Use this for initialization
    void Start()
    {

        // rb2D.AddForce(Vector2.right*3);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >10)
        {

            if (finished)
            {
                changeDir = UnityEngine.Random.RandomRange(0, 360);
                finished = false;
            }

            Debug.Log("changedir: " + changeDir);
            if(angle < changeDir)
            {
                angle += 1;
                transform.Rotate(new Vector3(0, 0, 1),changeDir * Time.deltaTime);
            }
            if (angle == changeDir)
            {
                angle = 0;
                finished = true;
                timer = 0;
            }

            
        }
        else
            timer += Time.deltaTime;
        Debug.Log(timer);


    }
}
