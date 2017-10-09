using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadLine : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playfx("Muerte");
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().fxAudio.Stop();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().musicAudio.Stop();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdateHealth(-100);
         //   SceneManager.LoadSceneAsync("MainMenu");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
