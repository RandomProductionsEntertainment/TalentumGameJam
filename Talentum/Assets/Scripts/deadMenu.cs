using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deadMenu : MonoBehaviour {

    [SerializeField]
    GameObject showMenu;
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
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerController>().CurrentHealth <= 0 )
        {
            Time.timeScale = 0;
            showMenu.SetActive(true);
        }
        if(player.GetComponent<PlayerController>().CurrentHealth > 0)
        {
            Time.timeScale = 1;
            showMenu.SetActive(false);

        }

    }
}
