
using FS2.Manager;
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

		public void Event02()
		{
			StopBikMusic();
			BikManager.Instsance.PlayBik("Bik02");
		}






	}
}
