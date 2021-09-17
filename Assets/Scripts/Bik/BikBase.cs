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
	}
}
