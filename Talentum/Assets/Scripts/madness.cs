using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class madness : MonoBehaviour
{

    float time = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    private void rotate()
    {
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int direction = UnityEngine.Random.RandomRange(0, 2);
        float move = UnityEngine.Random.RandomRange(0, 15);
        if (time > 1)
        {
            if (direction == 1)
            {
                gameObject.transform.Rotate(new Vector3(0, 0, transform.position.z + move));

            }
            else
            {
                gameObject.transform.Rotate(new Vector3(0, 0, transform.position.z - move));

            }

        }
    }
}
