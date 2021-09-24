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

		public void UpdateUICard(string cardName, int currentHp)
		{
			for (int i = 0; i < Cards.Count; i++)
			{
				if(Cards[i].cardName == cardName && Cards[i].isActiveAndEnabled)
				{
					Cards[i].UpdateUICard(currentHp);
				}
			}
		}
	}
}
