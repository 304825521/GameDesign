using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FS2.UI
{
    public class WGSkillBtn : WGBtn
{
        public GameObject Cover;
		public override void OnPointerClick(PointerEventData eventData)
		{
            //TODO:开始选取敌人的逻辑
        }

		/// <summary>
		/// 经过技能的时候的逻辑
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerEnter(PointerEventData eventData)
		{
            if (Cursor.visible)
            {
                Cover.SetActive(true);
            }
        }

		public override void OnPointerExit(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				Cover.SetActive(false);
			}
		}

		

		
	}
}
