using UnityEngine;
using System.Collections;

public static class AudioEffects{
	public static IEnumerator fadeOut(AudioSource audio,float time){
		float startVol = audio.volume;

		while (audio.volume > 0) {
			audio.volume -=  startVol * Time.deltaTime / time;
			yield return null;
		}

		audio.Stop ();
		audio.volume = startVol;
	}

	public static IEnumerator fadeIn(AudioSource audio,float time){
		float maxVol = audio.volume;
		audio.volume = 0;
		audio.Play ();

		while (audio.volume < maxVol) {
			audio.volume +=  Time.deltaTime / time;
			yield return null;
		}

	}
}
