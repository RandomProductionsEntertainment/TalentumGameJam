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
GameObject hardMode;


	// Use this for initialization
	void Start () {
        hardMode = GameObject.FindGameObjectWithTag("MainCamera");
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
        if (timeWithoutDie > 30 && hardMode.GetComponent<cameraController>().Speed == 4)
            hardMode.GetComponent<cameraController>().Speed += 0.5f;

        if(timeWithoutDie > 45 && hardMode.GetComponent<cameraController>().Speed == 4.5f)
            hardMode.GetComponent<cameraController>().Speed += 0.5f;
        if (timeWithoutDie > 65 && hardMode.GetComponent<cameraController>().Speed == 5f)
            hardMode.GetComponent<cameraController>().Speed += 1f;
        if (timeWithoutDie > 85 && hardMode.GetComponent<cameraController>().Speed == 6f)
        {
            hardMode.GetComponent<cameraController>().Speed += 0.5f;
            GameObject.Find("PropsFloorSpawner").GetComponent<PropsSpawner>().MaxTimeToSpawn -= 2;
        }

        timeWithoutDie += Time.deltaTime;
		if (player.GetComponent<PlayerController>().CurrentHealth <= 0 )
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("Muerte");
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().fxAudio.Stop();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().musicAudio.Stop();
            if(!messageSended)
            {
                messageSended = true;
                int message = UnityEngine.Random.RandomRange(0, 4);
                switch(message)
                {
                    case 0:
                        fuckingMessage.GetComponent<Text>().text = "Only " + timeWithoutDie + "?? \n YOU SUCK!! \n :')";
                        break;
                    case 1:
                        fuckingMessage.GetComponent<Text>().text = "Oh god... " + timeWithoutDie + "?? \n MY GRANDMA DOES IT BETTER!! \n :')";
                        break;
                    case 2:
                        fuckingMessage.GetComponent<Text>().text = "I've seen BLINDED people \n playing better than " + timeWithoutDie + " seconds!! \n :')";
                        break;
                    case 3:
                        fuckingMessage.GetComponent<Text>().text = "Really?? " + timeWithoutDie + "?? \n It's time for you to find new friends... \n :')";
                        break;

                }
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
