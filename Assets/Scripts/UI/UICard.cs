using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace FS2.UI
{
	public class UICard : UIWidget
	{
		public string cardName;

		public UIDynamic dynamic;
		private UIChoice UIChoice;

		private Text MpText;
		private Image MpBar;

		private Text HpText;
		private Image HpBar;

		public Text PersonName;
		public Image HeadSprite;

		private GameObject LoadingObj;
		public GameObject Base;

		protected override void Awake()
		{
			base.Awake();
			HpText = transform.Find("InfoBase/HPBase/HpStatus").gameObject.GetComponent<Text>();
			MpText = transform.Find("InfoBase/MPBase/MpStatus").gameObject.GetComponent<Text>();

			HpBar = transform.Find("InfoBase/HPBase/Bar").gameObject.GetComponent<Image>();
			MpBar = transform.Find("InfoBase/MPBase/Bar").gameObject.GetComponent<Image>();
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

		public void AfterFinishedAttack()
        {
			Base.SetActive(false);
			UIChoice = Game.UI.Get<UIChoice>();
			UIChoice.CtrlActionPannel(false);
		}

		/// <summary>
		/// 最终处理血量UI的方法
		/// </summary>
		/// <param name="currentHp">传进来的血量</param>
		public void UpdateUICard(int currentHp)
		{

			HpText.text = currentHp.ToString();


		}





	}

}