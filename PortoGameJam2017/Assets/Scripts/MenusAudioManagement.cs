using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusAudioManagement : MonoBehaviour {

    GameObject[] objs = null;

    void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
          Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        if (!(objs[0].name.CompareTo("MenuMusic") == 0 && (scene_name.CompareTo("gameMenu") == 0 || scene_name.CompareTo("creditsMenu") == 0 ||
            scene_name.CompareTo("storyMenu") == 0 || scene_name.CompareTo("gameOver") == 0)))
           Destroy(this.gameObject);
    }
}
