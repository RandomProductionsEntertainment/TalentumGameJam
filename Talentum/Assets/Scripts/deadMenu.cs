using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class deadMenu : MonoBehaviour {

    [SerializeField]
    GameObject showMenu;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject player;
    bool messageSended = false;
    float timeWithoutDie = 0.0f;
    public GameObject text;
    public GameObject fuckingMessage;


	// Use this for initialization
	void Start () {
        InvokeRepeating("chrono",0.1f,0.1f);
	}
	
    public void toRetry()
    {
        SceneManager.LoadSceneAsync("pruebaProcedural");
    }
    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void chrono()
    {
        text.GetComponent<Text>().text = timeWithoutDie.ToString();
    }
    public void setPauseMenuOff()
    {

        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        
    }
	// Update is called once per frame
	void Update () {
        timeWithoutDie += Time.deltaTime;
		if (player.GetComponent<PlayerController>().CurrentHealth <= 0 )
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("Muerte");
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().fxAudio.Stop();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().musicAudio.Stop();
            if(!messageSended)
            {
                messageSended = true;
                fuckingMessage.GetComponent<Text>().text = "Only " + timeWithoutDie + "?? \n YOU SUCK!! \n :')";
            }

            Time.timeScale = 0;
            timeWithoutDie = 0;
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
