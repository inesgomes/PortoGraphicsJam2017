using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayAudioManagement : MonoBehaviour
{
    string background_playing = "";
    Hashtable sounds = new Hashtable();

    void Awake()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("music"))
        {
            sounds.Add(obj.name, obj);
        }

        if (sounds.Count == 0)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        
        playAmbientMusic();
    }

    void Update()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        if (scene_name.CompareTo("gameMenu") == 0 || scene_name.CompareTo("creditsMenu") == 0 ||
            scene_name.CompareTo("storyMenu") == 0)
            Destroy(this.gameObject);
        else if (scene_name.CompareTo("gameOver") == 0)
        {
            playWinMusic();
        }
    }

    /*
     *Background Sounds
     */

    public void playSadMusic()
    {
        if (background_playing.CompareTo("sadMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["sadMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "sadMusic";
        }
    }

    public void playFightMusic()
    {
        if (background_playing.CompareTo("fightMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["fightMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "fightMusic";
        }
    }

    public void playAmbientMusic()
    {
        if (background_playing.CompareTo("ambientMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["ambientMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "ambientMusic";
        }
    }

    public void playBossMusic()
    {
        if (background_playing.CompareTo("bossMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["bossMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "bossMusic";
        }
    }

    public void playRunMusic()
    {
        if (background_playing.CompareTo("runMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["runMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "runMusic";
        }
    }

    public void stopRunMusic()
    {
        ((GameObject)sounds["runMusic"]).GetComponent<AudioSource>().Stop();
        playAmbientMusic();
    }

    public void playWinMusic()
    {
        if (background_playing.CompareTo("winMusic") != 0)
        {
            if (background_playing.CompareTo("") != 0)
                ((GameObject)sounds[background_playing]).GetComponent<AudioSource>().Stop();
            ((GameObject)sounds["winMusic"]).GetComponent<AudioSource>().Play();
            background_playing = "winMusic";
        }
    }

    /*
     * Instantaneous Sounds
     */

    public void playMonsterDieMusic()
    {
        ((GameObject)sounds["monsterDieMusic"]).GetComponent<AudioSource>().Play();
    }

    public void playPortalMusic()
    {
        ((GameObject)sounds["portalMusic"]).GetComponent<AudioSource>().Play();
    }

    public void playPunchMusic()
    {
        ((GameObject)sounds["punchMusic"]).GetComponent<AudioSource>().Play();
    }

    public void playMissPunchMusic()
    {
        ((GameObject)sounds["missPunchMusic"]).GetComponent<AudioSource>().Play();
    } 
}