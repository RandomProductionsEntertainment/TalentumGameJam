using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    public float speed = 10f;
    public float takeOffJumpSpeed = 3f;
    float jumpSpeed;
    bool isGrounded = true;
    float maxY;
    public float maxJumpHeight;
    bool maxReached = false;
    private int direction;

    // Use this for initialization
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 move = Vector2.zero;

        ControlsDirection(ref move);
        rb2D.transform.position = new Vector2(rb2D.transform.position.x + move.x * speed * Time.deltaTime, rb2D.transform.position.y + move.y * speed * Time.deltaTime);

    }

    
    void ControlsDirection(ref Vector2 move)
    {
       
        switch(direction)
        {
            case 0:
                if (Input.GetKey("a")) move.x = -1;
                else if (Input.GetKey("d")) move.x = 1;
                if (Input.GetKey("w")) move.y = 1;
                else if (Input.GetKey("s")) move.y = -1;
                break;
            case 1:
                if (Input.GetKey("a")) move.y = -1;
                else if (Input.GetKey("d")) move.y = 1;
                if (Input.GetKey("w")) move.x = -1;
                else if (Input.GetKey("s")) move.x = 1;
                break;
            case 2:
                if (Input.GetKey("a")) move.x = 1;
                else if (Input.GetKey("d")) move.x = -1;
                if (Input.GetKey("w")) move.y = -1;
                else if (Input.GetKey("s")) move.y = 1;
                break;
            case 3:
                if (Input.GetKey("a")) move.y = 1;
                else if (Input.GetKey("d")) move.y = -1;
                if (Input.GetKey("w")) move.x = 1;
                else if (Input.GetKey("s")) move.x = -1;
                break;
            default:
                break;
        }
    }

    public void ChangeDirection(int n)
    {
        direction = n;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && !isGrounded)
        {
            isGrounded = true;
            maxReached = false;
        }


    }

}


/*move.x = Input.GetAxis("Horizontal");
        move.y = 0f;

        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            maxY = transform.position.y + maxJumpHeight;
            move.y = takeOffJumpSpeed;
            jumpSpeed = takeOffJumpSpeed;
            isGrounded = false;
        }

        else if (!isGrounded)
        {
            
                if (transform.position.y < maxY)
                    maxReached = true;

                /*if (!maxReached && Input.GetAxis("Vertical") == 1)
                {
                    move.y = Input.GetAxis("Vertical");
                }
                else
                {
                    move.y = move.y - 0.1f;
                }
                if(!maxReached)
                {
                    jumpSpeed = jumpSpeed + 0.2f;
                }
                else
                {
                    jumpSpeed = jumpSpeed - 0.02f;
                }


                move.y = jumpSpeed;
            

        }*/
/*else
    move.y = Input.GetAxis("Vertical");*/
