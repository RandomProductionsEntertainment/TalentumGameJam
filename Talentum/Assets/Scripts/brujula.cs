using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brujula : MonoBehaviour {

    int angle = 0;
    bool finished = true;
    float timer = 0;
    int changeDir = 0;
    public Text north;
    public Text south;
    public Text east;
    public Text west;

    // Use this for initialization
    void Start()
    {
        north.enabled = false;
        south.enabled = false;
        east.enabled = false;
        west.enabled = false;

    }
    private void OnGUI()
    {
        if (north.enabled && timer > 3)
        {
            north.enabled = false;

        }
        else
        {
            north.text = "Back to ANORMAL!";
        }
        if (south.enabled && timer > 3)
            south.enabled = false;
        else
            south.text = "Now UP is DOWN!";
        if (east.enabled && timer > 3)
            east.enabled = false;
        else
            east.text = "RUN and you'll JUMP!";
        if (west.enabled && timer > 3)
            west.enabled = false;
        else
            west.text = "NORTH to the WEST!";
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 10)
        {

            if (finished)
            {
                changeDir = UnityEngine.Random.RandomRange(0, 360);
                finished = false;
            }


            if (angle < changeDir)
            {
                angle += 1;
                transform.Rotate(new Vector3(0, 0, 1), changeDir * Time.deltaTime);
            }
            if (angle == changeDir)
            {
                float zAngle = transform.rotation.z;
                if (zAngle >= -45 && zAngle <= 45 || zAngle >= 315 && zAngle <= 405 || zAngle <= -315 && zAngle >= -405)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(0);
                    north.enabled = true;
                }
                else if (zAngle <= 135 && zAngle >= 45 || zAngle >= -315 && zAngle <= -225)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(3);
                    west.enabled = true;
                }
                else if (zAngle >= 135 && zAngle <= 225 || zAngle >= -225 && zAngle <= -135)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(2);
                    south.enabled = true;
                }
                else if (zAngle <= 315 && zAngle >= 225 || zAngle >= -135 && zAngle <= -45)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeDirection(1);
                    east.enabled = true;
                }
                angle = 0;
                finished = true;
                timer = 0;
            }


        }
        else
            timer += Time.deltaTime;



    }
}
