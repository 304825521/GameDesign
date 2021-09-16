﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FS2.UI
{
	public class ActionButtons : UIWidget, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
	{
		public class EventTriggerButton : EventTrigger
		{
			//TODO:回去看看如何触发的
		}

		public EventTriggerButton Click;
		public void OnPointerClick(PointerEventData eventData)
		{

			if (Cursor.visible)
			{
				Sprite sprite = null;
				string name = "Click" + this.gameObject.name;
				switch (name)
				{
					case "ClickCombatBtn":
						sprite = GameManager.GamePrefab.ClickCombatBtn;
						break;
					case "ClickAttackBtn":
						sprite = GameManager.GamePrefab.ClickAttactBtn;
						break;
					case "ClickAutoBtn":
						sprite = GameManager.GamePrefab.ClickAutoBtn;
						break;
					case "ClickRunBtn":
						sprite = GameManager.GamePrefab.ClickRunBtn;
						break;
					case "ClickToolsBtn":
						sprite = GameManager.GamePrefab.ClickToolsBtn;
						break;
					default:
						break;
				}
				this.gameObject.GetComponent<Image>().sprite = sprite;
				this.gameObject.GetComponent<Image>().SetNativeSize();
				switch (name)
				{
					case "ClickCombatBtn":
						
						break;
					case "ClickAttackBtn":
						sprite = GameManager.GamePrefab.ClickAttactBtn;
						break;
					case "ClickAutoBtn":
						sprite = GameManager.GamePrefab.ClickAutoBtn;
						break;
					case "ClickRunBtn":
						sprite = GameManager.GamePrefab.ClickRunBtn;
						break;
					case "ClickToolsBtn":
						sprite = GameManager.GamePrefab.ClickToolsBtn;
						break;
					default:
						break;
				}

			}	
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				Sprite sprite = null;
				string name = "Enter" + this.gameObject.name;
				switch (name)
				{
					case "EnterCombatBtn":
						sprite = GameManager.GamePrefab.EnterCombatBtn;
						break;
					case "EnterAttackBtn":
						sprite = GameManager.GamePrefab.EnterAttactBtn;
						break;
					case "EnterAutoBtn":
						sprite = GameManager.GamePrefab.EnterAutoBtn;
						break;
					case "EnterRunBtn":
						sprite = GameManager.GamePrefab.EnterRunBtn;
						break;
					case "EnterToolsBtn":
						sprite = GameManager.GamePrefab.EnterToolsBtn;
						break;
					default:
						break;
				}
				this.gameObject.GetComponent<Image>().sprite = sprite;
				this.gameObject.GetComponent<Image>().SetNativeSize();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				Sprite sprite = null;
				string name = "Normal" + this.gameObject.name;
				switch (name)
				{
					case "NormalCombatBtn":
						sprite = GameManager.GamePrefab.NormalCombatBtn;
						break;
					case "NormalAttackBtn":
						sprite = GameManager.GamePrefab.NormalAttactBtn;
						break;
					case "NormalAutoBtn":
						sprite = GameManager.GamePrefab.NormalAutoBtn;
						break;
					case "NormalRunBtn":
						sprite = GameManager.GamePrefab.NormalRunBtn;
						break;
					case "NormalToolsBtn":
						sprite = GameManager.GamePrefab.NormalToolsBtn;
						break;
					default:
						break;
				}
				this.gameObject.GetComponent<Image>().sprite = sprite;
				this.gameObject.GetComponent<Image>().SetNativeSize();
			}
		}
	}

}