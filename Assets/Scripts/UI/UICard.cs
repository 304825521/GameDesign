using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FS2.UI
{
	public class UICard : UIWidget
	{
		public string cardName;

		public UIDynamic dynamic;
		private UIChoice UIChoice;

		public Text MpText;
		public Image MpBar;

		public Text HpText;
		public Image HpBar;

		public Text PersonName;
		public Image HeadSprite;

		private GameObject LoadingObj;
		public GameObject Base;

	
		public void IsOn()
		{
			//gameSetActive(value: true);
			gameObject.SetActive(true);
		}

		public void IsOff()
		{
			gameObject.SetActive(false);
		}

		/// <summary>
		/// 外部调用开始Loading的逻辑
		/// </summary>
		public void StartLoading()
		{
			Debug.Log("正式开始Loading的逻辑");
			Loading.Instsance.Compelete += OnAfterLoadingCompelete;
			LoadingObj = transform.Find("Loading").gameObject;
			Animator animator = LoadingObj.GetComponent<Animator>();
			animator.SetTrigger("Loading");
			//TODO:这里由人物速度决定
			animator.speed = 1f;
		}

		public void OnAfterLoadingCompelete()
		{
			//TODO:检测别的player是否在运行
			UIChoice = Game.UI.Get<UIChoice>();
			UIChoice.ActionPannel.GetComponent<ActionPannel>().OpenPannel(cardName);
			Base.SetActive(true);
		}


	}

}