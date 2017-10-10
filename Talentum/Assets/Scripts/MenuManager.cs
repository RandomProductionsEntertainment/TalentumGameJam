using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    GameObject newgame;
    [SerializeField]
    GameObject controlsbutton;
    [SerializeField]
    GameObject credits;
    [SerializeField]
    GameObject quitbutton;
    [SerializeField]
    GameObject controls;
    [SerializeField]
    GameObject creditsmenu;


    // Use this for initialization
    void Start () {
		
	}
	
    public void showControls()
    {
        newgame.SetActive(false);
        controlsbutton.SetActive(false);
        credits.SetActive(false);
        quitbutton.SetActive(false);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        controls.SetActive(true);
    }

    public void newGame()
    {
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        SceneManager.LoadSceneAsync("pruebaProcedural");
    }
    public void closeControls()
    {
        newgame.SetActive(true);
        controlsbutton.SetActive(true);
        credits.SetActive(true);
        quitbutton.SetActive(true);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        controls.SetActive(false);
    }

    public void showCredits()
    {
        newgame.SetActive(false);
        controlsbutton.SetActive(false);
        credits.SetActive(false);
        quitbutton.SetActive(false);
        controls.SetActive(false);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        creditsmenu.SetActive(true);
    }
    public void closeCredits()
    {
        newgame.SetActive(true);
        controlsbutton.SetActive(true);
        credits.SetActive(true);
        quitbutton.SetActive(true);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        creditsmenu.SetActive(false);
    }
    public void quit()
    {
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
