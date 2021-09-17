
using FS2.UI;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace FS2
{
	public static class Game
	{
		public static UIManager UI { get; private set; }
		public static IKernel Kernel { get; private set; }
		public static AudioPlayer AudioPlayer { get; private set; }
		public static DialogManager Dialog { get; private set; }
		public static AudioMixer AudioMixer { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnBeforeSceneLoad()
		{
			StandardKernel standardKernel = new StandardKernel(new GlobalBindingModule());
			UI = standardKernel.Get<UIManager>(Array.Empty<IParameter>());
			Kernel = standardKernel;
			AudioPlayer = standardKernel.Get<AudioPlayer>(Array.Empty<IParameter>());
			Dialog = standardKernel.Get<DialogManager>(Array.Empty<IParameter>());
			if (Game.AudioMixer == null)
			{
				Game.AudioMixer = (Resources.Load("AudioMixer/AudioMixer") as AudioMixer);
			}
			Application.targetFrameRate = 60;
		}
	}
}
