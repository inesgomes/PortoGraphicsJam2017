using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour {

    public GameObject panelPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
	}

    void pause()
    {
        //pause
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
    }

    public void resume()
    {
        pause();
    }

    public void gameMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("gameMenu");
    }
}
