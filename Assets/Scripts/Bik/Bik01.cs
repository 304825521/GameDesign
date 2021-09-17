
using UnityEngine;
using UnityEngine.Playables;
namespace FSGame.Manager.Bik
{
	public class Bik01 : BikBase
	{
		public void Event01()
		{
			StartBikMusic("018music");
		}
		public void StartBikMusic(string name)
		{
			AudioClip clip = Resources.Load<AudioClip>("Audio/Music/" + name);
			AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
			AudioSource.clip = clip;
			AudioSource.loop = true;
			AudioSource.Play();
		}

		public void StopBikMusic()
		{
			AudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
			AudioSource.Stop();
		}




	}
}
