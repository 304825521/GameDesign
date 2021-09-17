using FS2.Manager;
using FS2.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.FSM.Main
{
	public class MainMenu : MainState
	{
		private UIMain mainMenu;

		protected override void OnEnable()
		{
			EnterMain();
		}

		private void EnterMain()
		{
			Game.AudioPlayer.ChangeMusic("041music", true);
			this.OpenMain();
		}

		private void OpenMain()
		{
			this.mainMenu = base.UI.Open<UIMain>();
			if (this.mainMenu == null)
			{
				return;
			}
			this.mainMenu.NewGamePressed = new Action(this.OnNewGame);
		}

		private void OnNewGame()
		{
			this.mainMenu.Hide();
			Game.AudioPlayer.StopCurrentSource();
			BikManager.Instsance.PlayBik("Bik01");
		}
	}

}