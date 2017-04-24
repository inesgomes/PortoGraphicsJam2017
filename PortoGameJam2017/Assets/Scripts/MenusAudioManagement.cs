using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusAudioManagement: MonoBehaviour
{

    AudioSource audio;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("music").Length > 1)
            Destroy(this.gameObject);


        audio = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        if (!audio.isPlaying)
            audio.Play();

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        if (!(scene_name.CompareTo("gameMenu") == 0 || scene_name.CompareTo("creditsMenu") == 0 ||
            scene_name.CompareTo("storyMenu") == 0))
            audio.Stop();
    }
   
}