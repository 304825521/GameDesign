using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{
    public class UIPerson : UIForm
    {
        
        CtrlPerson controller;

        public List<UICard> Cards;

		protected override void OnEnable()
		{
			if (controller == null)
			{
				controller = new CtrlPerson(this);
			}
		}




	}
}
