using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brujula : MonoBehaviour {

    int angle = 0;
    bool finished = true;
    float timer = 0;
    int changeDir = 0;


    // Use this for initialization
    void Start()
    {

     
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

 
            if(angle < changeDir)
            {
                angle += 1;
                transform.Rotate(new Vector3(0, 0, 1),changeDir * Time.deltaTime);
            }
            if (angle == changeDir)
            {
                if (angle >= -45 && angle <= 45 || angle >= 315 && angle <= 405 || angle <= -315 && angle >= -405)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(0);
                else if (angle <= 135 && angle >= 45 || angle >= -315 && angle <= -225)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(3);
                else if (angle >= 135 && angle <= 225 || angle >= -225 && angle <= -135)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(2);
                else if (angle <= 315 && angle >= 225 || angle >= -135 && angle <= -45)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(1);
                angle = 0;
                finished = true;
                timer = 0;
            }

            
        }
        else
            timer += Time.deltaTime;



    }
}
