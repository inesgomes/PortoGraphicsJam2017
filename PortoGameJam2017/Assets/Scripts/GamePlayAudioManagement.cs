using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayAudioManagement : MonoBehaviour
{
	Hashtable sounds = new Hashtable();

	AudioSource current_background;


	void Awake()
	{
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("music"))
		{
			sounds.Add(obj.name, obj);
		}

		if (sounds.Count == 0)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);

		current_background = ((GameObject)sounds["ambientMusic"]).GetComponent<AudioSource>();
	}

	void Update()
	{
		string scene_name = SceneManager.GetActiveScene().name;

		if (scene_name.CompareTo("gameMenu") == 0 || scene_name.CompareTo("creditsMenu") == 0 ||
			scene_name.CompareTo("storyMenu") == 0)
			Destroy(this.gameObject);
		else if (scene_name.CompareTo("gameOver") == 0)
		{
			stopRunMusic();
			playWinMusic();
		}
	}

	/*
     *Background Sounds
     */

	public void playSadMusic()
	{
		AudioSource audio = ((GameObject)sounds["sadMusic"]).GetComponent<AudioSource>();
		if (audio != current_background)
		{
			StartCoroutine (AudioEffects.fadeOut (current_background, 5.0f));
			StartCoroutine (AudioEffects.fadeIn (audio, 5.0f));
			current_background = audio;
		}
	}

	public void playFightMusic()
	{
		AudioSource audio = ((GameObject)sounds["fightMusic"]).GetComponent<AudioSource>();
		if(audio != current_background)
		{
			StartCoroutine(AudioEffects.fadeOut(current_background,5.0f));
			StartCoroutine (AudioEffects.fadeIn (audio, 5.0f));
			current_background = audio;
		}
	}

	public void playAmbientMusic()
	{
		AudioSource audio = ((GameObject)sounds["ambientMusic"]).GetComponent<AudioSource>();
		if (audio != current_background)
		{
			StartCoroutine (AudioEffects.fadeOut (current_background, 5.0f));
			StartCoroutine (AudioEffects.fadeIn (audio, 5.0f));
			current_background = audio;
		}
	}

	public void playBossMusic()
	{
		AudioSource audio = ((GameObject)sounds["bossMusic"]).GetComponent<AudioSource>();
		if (audio != current_background)
		{
			StartCoroutine (AudioEffects.fadeOut (current_background, 5.0f));
			StartCoroutine (AudioEffects.fadeIn (audio, 5.0f));
			current_background = audio;
		}
	}



	public void playWinMusic()
	{
		AudioSource audio = ((GameObject)sounds["winMusic"]).GetComponent<AudioSource>();

		if (audio != current_background)
		{
			StartCoroutine (AudioEffects.fadeOut (current_background, 5.0f));
			StartCoroutine (AudioEffects.fadeIn (audio, 5.0f));
			current_background = audio;
		}
	}

	/*
     * Instantaneous Sounds
     */

	public void playMonsterDieMusic()
	{
		AudioSource audio = ((GameObject)sounds["monsterDieMusic"]).GetComponent<AudioSource>();
		if (audio.isPlaying)
			audio.Stop();

		audio.Play();
	}

	public void playPortalMusic()
	{
		AudioSource audio = ((GameObject)sounds["portalMusic"]).GetComponent<AudioSource>();

		playAmbientMusic ();
		audio.Play();
	}

	public void playPunchMusic()
	{
		AudioSource audio = ((GameObject)sounds["punchMusic"]).GetComponent<AudioSource>();
		if (audio.isPlaying)
			audio.Stop();

		audio.Play();
	}

	public void playMissPunchMusic()
	{
		AudioSource audio = ((GameObject)sounds["missPunchMusic"]).GetComponent<AudioSource>();
		if (audio.isPlaying)
			audio.Stop();

		audio.Play();
	}

	public void playRunMusic()
	{
		AudioSource audio = ((GameObject)sounds["runMusic"]).GetComponent<AudioSource>();
		if (!audio.isPlaying)
		{
			audio.Play();
		}
	}

	public void stopRunMusic()
	{
		AudioSource audio = ((GameObject)sounds["runMusic"]).GetComponent<AudioSource>();
		audio.Stop();
	}
}