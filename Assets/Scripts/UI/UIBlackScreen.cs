using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FS2.UI
{
	public class UIBlackScreen : UIForm
	{
		Image image;

		protected override void Awake()
		{
			base.Awake();
			image = this.transform.Find("Image").gameObject.GetComponent<Image>();
			image.color = new Color(1, 1, 1, 0);
		}

		public override void Show()
		{
			base.Show();
			//TODO:逻辑
		}


	}
}
