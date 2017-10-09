using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject controls;
    [SerializeField]
    GameObject animControls;

	// Use this for initialization
	void Start () {
		
	}
	
    public void showControls()
    {
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
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("SFX Select");
        controls.SetActive(false);
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
