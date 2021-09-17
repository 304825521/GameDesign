using FS2.Utility;
using System;
using UnityEngine;

namespace FS2
{
	public class AudioPlayer
	{
		private AudioSource[] music_source;

		private AudioSource current_source;

		public AudioPlayer()
		{
			this.music_source = new AudioSource[2];
			create_audio_source();
		}

		private void create_audio_source()
		{
			GameObject gameObject = new GameObject("AudioPlayer");
			gameObject.AddComponentIfNotExist<AudioSource>(false);
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject2 = new GameObject(string.Format("Source_{0:00}", i));
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.transform.localPosition = Vector3.zero;
				this.music_source[i] = gameObject2.AddComponentIfNotExist<AudioSource>(false);
				this.music_source[i].loop = true;
				this.music_source[i].playOnAwake = false;
				this.music_source[i].Stop();
			}
		}

		public void ChangeMusic(string _name, bool isLoop)
		{
			AudioSource audio = get_free_source();
			current_source = audio;
			audio.clip = Resources.Load<AudioClip>("Audio/Music/" + _name);
			audio.loop = isLoop;
			audio.playOnAwake = true;
			audio.Play();
		}

		public void PlaySound(string name)
		{
			string pathSound = "Audio/Sound/" + name;
			AudioClip clip = Resources.Load<AudioClip>(pathSound);
			AudioSource audio = get_free_source();
			current_source = audio;
			audio.PlayOneShot(clip);

		}

		private AudioSource get_free_source()
		{
			for (int i = 0; i < 2; i++)
			{
				if (!(this.music_source[i] == this.current_source))
				{
					this.music_source[i].outputAudioMixerGroup = Game.AudioMixer.FindMatchingGroups("Music")[0];
					return this.music_source[i];
				}
			}
			return null;
		}

		public void StopCurrentSource()
		{
			current_source.Pause();
		}
	}
}