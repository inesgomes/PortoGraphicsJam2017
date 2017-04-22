using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions: MonoBehaviour {

    public void go_to_menu() {
        SceneManager.LoadScene("gameMenu");
    }

    public void go_to_credits()
    {
        SceneManager.LoadScene("creditsMenu");
    }

    public void go_to_story()
    {
        SceneManager.LoadScene("storyMenu");
    }

    public void go_to_play()
    {
      SceneManager.LoadScene("route1");
    }

    public void go_to_exit()
    {
        Application.Quit();
    }
}
