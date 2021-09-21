using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using UnityEngine.Timeline;
using FS2.Manager;

namespace FSGame.Manager.Bik
{
	public class BikBase : MonoBehaviour
	{
		GameObject VideoPlayer;
		protected AudioSource AudioSource;
		protected PlayableDirector PlayableDirector;
		protected virtual void OnEnable()
		{
			VideoPlayer = GameObject.Find("Video Player");
			PlayableDirector = GetComponent<PlayableDirector>();
			BikManager.Instsance.InitBik(VideoPlayer, PlayableDirector);
		}

		protected virtual void StartBikMusic(string name)
		{
			AudioClip clip = Resources.Load<AudioClip>("Audio/Music/" + name);
			AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
			AudioSource.clip = clip;
			AudioSource.loop = true;
			AudioSource.Play();
		}

		protected virtual void StopBikMusic()
		{
			AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
			AudioSource.Stop();
		}
	}
}
