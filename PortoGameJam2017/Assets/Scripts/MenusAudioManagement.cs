using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusAudioManagement: MonoBehaviour
{

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");

        if (obj.Length == 0 || obj.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        if (!(scene_name.CompareTo("gameMenu") == 0 || scene_name.CompareTo("creditsMenu") == 0 ||
            scene_name.CompareTo("storyMenu") == 0))
            Destroy(this.gameObject);
    }
   
}