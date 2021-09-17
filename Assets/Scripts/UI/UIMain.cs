using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{
	public class UIMain : UIForm
	{

		public GameObject btnNewGame;

		public Action NewGamePressed;

		public override void Show()
		{
			base.Show();
		}

		public override void Hide()
		{
			base.Hide();
		}

		public void OnBtnNewGamePressed()
		{
			Action newGamePressed = this.NewGamePressed;
			if (newGamePressed == null)
			{
				return;
			}
			newGamePressed();
		}
	}

}