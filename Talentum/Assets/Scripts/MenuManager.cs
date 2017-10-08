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
        controls.SetActive(true);
    }

    public void newGame()
    {
        SceneManager.LoadSceneAsync("pruebaProcedural");
    }
    public void closeControls()
    {
        controls.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
