using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FS2.UI
{
	public class WGMainBtn : WGBtn
	{
		public override void OnPointerEnter(PointerEventData eventData)
		{
			GetComponent<Text>().color = Color.red;
			base.OnPointerEnter(eventData);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			GetComponent<Text>().color = Color.black;
			base.OnPointerExit(eventData);
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			GetComponent<Text>().color = Color.grey;
			base.OnPointerClick(eventData);
		}
	}
}
