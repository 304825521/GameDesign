using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FS2.UI
{
	public class UICard : UIWidget
	{

		public UIDynamic dynamic;

		public Text MpText;
		public Image MpBar;

		public Text HpText;
		public Image HpBar;

		public Text PersonName;
		public Image HeadSprite;

		public void IsOn()
		{
			//gameSetActive(value: true);
			gameObject.SetActive(true);
		}

		public void IsOff()
		{
			gameObject.SetActive(false);
		}


	}

}