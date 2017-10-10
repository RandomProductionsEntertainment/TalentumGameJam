using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    RaycastHit2D hitInfo;
    Collider2D[] colliders;
    public float speed = 10f;
    public float jumpSpeed;
    bool isGrounded = true;
    float maxY;
    public float maxJumpHeight;
    bool maxReached = false;
    private int direction;
    float initialHealth = 100;
    float currentHealth;
    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    Image health;
    float aux;
    bool newHealth;
    bool addedHealth = false;
    float auxHealth = 0.5f;
    bool passed = false;
    Animator anim;
    float auxHealth2 = 0.25f;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = initialHealth;
        health = health1;
        health2.enabled = false;
        health3.enabled = false;
        health4.enabled = false;

        anim = gameObject.GetComponent<Animator>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim.Play("Running");
    }

    private void OnGUI()
    {

        if (health.fillAmount <= auxHealth2)
        {
            health = health4;
            health4.enabled = true;
            health3.enabled = false;
        }
        else if (health.fillAmount <= auxHealth)
        {
            if (!passed)
            {
                auxHealth = 1f;
                health.fillAmount = 1f;
                passed = true;
            }
            if (health.fillAmount <= 0.5f)
            {
                auxHealth2 = 1f;
                health.fillAmount = 1f;
            }


            health = health3;
            health3.enabled = true;
            health2.enabled = false;
        }
        else if (health.fillAmount <= 0.75f)
        {
            health = health2;
            health2.enabled = true;
            health1.enabled = false;
        }
        else if (health.fillAmount <= 1)
            health = health1;

        if (addedHealth)
        {
            if (health.fillAmount <= currentHealth / 100)
                addedHealth = false;

            health.fillAmount -= 0.05f * Time.deltaTime;


        }
        else
            health.fillAmount = currentHealth / 100;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 move = Vector2.zero;

        ControlsDirection(ref move);
        if(!isGrounded)
        {
            Debug.Log("playjump");
            anim.SetBool("grounded", false);
            anim.Play("jump");
            if (transform.position.y >= maxY)
            {
                maxReached = true;
            }

            if (!maxReached)
                move.y = jumpSpeed;// Input.GetAxis("Vertical") * jumpSpeed;
            else
            {
                move.y = -jumpSpeed;
            }

        }
       
        rb2D.transform.position = new Vector2(rb2D.transform.position.x + move.x * speed * Time.deltaTime, rb2D.transform.position.y + move.y * speed * Time.deltaTime);
        // health.fillAmount -= 0.25f * Time.deltaTime;
        anim.SetBool("grounded", true);
    }

    

    void ControlsDirection(ref Vector2 move)
    {
        move.x = 1;
        switch (direction)
        {
            case 0:
                if (Input.GetKey("a")) move.x = -1;
                else if (Input.GetKey("d")) move.x = 1;
                if (Input.GetKey("w"))
                { 
                    if (isGrounded)
                    {
                        isGrounded = false;
                        maxY = transform.position.y + maxJumpHeight;
                    }
                }
                else if (Input.GetKey("s")) move.y = -1;
                break;
            case 1:
                if (Input.GetKey("a")) move.y = -1;
                else if (Input.GetKey("d"))
                {
                    
                    if (isGrounded)
                    {
                        isGrounded = false;
                        maxY = transform.position.y + maxJumpHeight;
                    }
                }
                if (Input.GetKey("w")) move.x = -1;
                else if (Input.GetKey("s")) move.x = 1;
                break;
            case 2:
                if (Input.GetKey("a")) move.x = 1;
                else if (Input.GetKey("d")) move.x = -1;
                if (Input.GetKey("w")) move.y = -1;
                else if (Input.GetKey("s"))
                {
                    
                    if (isGrounded)
                    {
                        isGrounded = false;
                        maxY = transform.position.y + maxJumpHeight;
                    }
                }
                break;
            case 3:
                if (Input.GetKey("a"))
                {
                    GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Jump");
                    if (isGrounded)
                    {
                        isGrounded = false;
                        maxY = transform.position.y + maxJumpHeight;
                    }
                }
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
    public void UpdateHealth(float health)
    {
        currentHealth += health;
        addedHealth = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;
            maxReached = false;
        }

       

        if (collision.gameObject.tag == "Obstacle" && !collision.gameObject.GetComponent<Obstacle>().Touched)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Hit");
            UpdateHealth(-25f);
         //   anim.SetBool("hit", true);
            Debug.Log("playhit");
            anim.Play("hit");
           // anim.SetBool("hit", false);


        }

        if (collision.gameObject.tag == "Bottom" && !collision.gameObject.GetComponent<Obstacle>().Touched)
        {
            maxReached = true;
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Hit");
            UpdateHealth(-25f);
         //   anim.SetBool("hit", true);
            Debug.Log("playHIT");
            anim.Play("hit");
          //  anim.SetBool("hit", false);
        }
    }

}

