using FS2.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;


namespace FS2.Manager
{
	public enum GameMode
	{
		GamePlay,
		DialogBik,
		NormalDialog,
		Normal,
		BikPlay,
	}
	public class BikManager : MonoSingleton<BikManager>
    {
		//游戏状态
		public GameMode gameMode;
		//存储所有的Bik动画
		public List<GameObject> BikObjs;
		//获取当前播放的Bik
		private GameObject CurrentBik;
		//播放音乐的组件
		private AudioSource AudioSource;
		//当前的PlayableDirector
		private PlayableDirector CurrentDircetor;

		private GameObject CurrentVideoPlayer;
		//对话UI
		UIDialog Dialog;
		//判断是否全部对话结束
		private bool isFinished = false;

        public bool IsFinished
		{
            get { return isFinished; }
            set
            {
				isFinished = value;
				if(isFinished == true)
                {
					gameMode = GameMode.BikPlay;
                }
            }
            
		}

        private void OnEnable()
		{
			CurrentBik = BikObjs[0];
		}

		//播放Bik动画
		public void PlayBik(string name)
		{
			for (int i = 0; i < BikObjs.Count; i++)
			{
				if(BikObjs[i].name == name)
				{
					if (CurrentBik != null) CurrentBik.SetActive(false);
					BikObjs[i].SetActive(true);
					CurrentBik = BikObjs[i];
				}
			}
		}

		
		public void InitBik(GameObject CurrentVideoPlayer, PlayableDirector playableDirector)
		{
			this.CurrentVideoPlayer = CurrentVideoPlayer;
			CurrentDircetor = playableDirector;
		}

		public void ResumeTimeLineForBik()
		{
			CurrentDircetor.Play();
			CurrentVideoPlayer.GetComponent<VideoPlayer>().Play();
			Dialog.Hide();
		}


		public void PauseTimeLineForBik()
		{
			gameMode = GameMode.DialogBik;
			CurrentDircetor.Pause();
			CurrentVideoPlayer.GetComponent<VideoPlayer>().Pause();
			Dialog = Game.UI.Open<UIDialog>();
		}

		private void Update()
		{
			if(gameMode == GameMode.DialogBik)
			{
				Debug.Log("检测鼠标点击");
				//TODO:需要改变鼠标的样子
				//TODO:暂时用space代替鼠标点击
				if(Input.GetKeyDown(KeyCode.Space))
                {
					//TODO:检测是否对话结束
					Debug.Log("123");
					Dialog = Game.UI.Get<UIDialog>();
					if(Dialog == null)
                    {
						Debug.Log("没有获取到UIDialog");
						return;
                    }
                    else
                    {
						Dialog.PlayDialog();
                    }
                }
			}
			if (gameMode == GameMode.GamePlay)
			{
				ResumeTimeLineForBik();
			}
		}

	}

}