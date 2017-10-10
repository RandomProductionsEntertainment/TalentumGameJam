﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deadMenu : MonoBehaviour {

    [SerializeField]
    GameObject showMenu;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
    public void toRetry()
    {
        SceneManager.LoadSceneAsync("pruebaProcedural");
    }
    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void setPauseMenuOff()
    {

        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        
    }
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<PlayerController>().CurrentHealth <= 0 )
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("Muerte");
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().fxAudio.Stop();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().musicAudio.Stop();
            Time.timeScale = 0;
            showMenu.SetActive(true);
        }
        if(player.GetComponent<PlayerController>().CurrentHealth > 0 && !pauseMenu.active)
        {
            Time.timeScale = 1;
            showMenu.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<PlayerController>().CurrentHealth > 0)
        {
            if(pauseMenu.active)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }

        }


    }
}
