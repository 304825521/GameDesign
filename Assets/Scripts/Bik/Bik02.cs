using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using UnityEngine.Timeline;
using FS2.FSM.Battle;

namespace FSGame.Manager.Bik
{
	public class Bik02 : BikBase
	{
		public void Event01()
		{
			base.StartBikMusic("045music");
		}

		public void Event02()
		{
			base.StopBikMusic();
			base.StartBikMusic("029music");
		}

		public void Event03()
		{
			base.StopBikMusic();
			base.StartBikMusic("045music");
		}

		public void Event04()
		{
			
			BattleManager.Instsance.Bik02Battle();
		}
	}
}
