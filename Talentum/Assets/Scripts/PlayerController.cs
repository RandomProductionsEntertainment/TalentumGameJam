﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    float initialHealth = 100;
    float currentHealth;
    public Image health;
    float aux;
    bool newHealth;


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

        
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnGUI()
    {
        if(newHealth)
        {

        }
        health.fillAmount = currentHealth / 100;
    }
    // Update is called once per frame
    void Update()
    {

        Vector2 move = Vector2.zero;

        ControlsDirection(ref move);
        if(!isGrounded)
        {
            if (transform.position.y >= maxY)
            {
                maxReached = true;
            }

            if(!maxReached)
                move.y = 1;
            else 
            {
                    move.y = -0.5f;
            }
            
        }
        rb2D.transform.position = new Vector2(rb2D.transform.position.x + move.x * speed * Time.deltaTime, rb2D.transform.position.y + move.y * speed * Time.deltaTime);
       // health.fillAmount -= 0.25f * Time.deltaTime;
    }

    

    void ControlsDirection(ref Vector2 move)
    {

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
    public void UpdateHealth(float newHealth)
    {
        currentHealth += newHealth;
        aux = newHealth;
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
           /* if (currentHealth == 0)
                SceneManager.LoadSceneAsync("MainMenu");*/
        }


    }

}

