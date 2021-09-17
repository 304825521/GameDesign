using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using FS2.Data;
using FS2.Manager;

namespace FS2.UI
{
    public class UIDialog : UIForm
    {
		#region typewriter
		Typewriter typewriter;

		TypewriterState state;

		public TypewriterState State
		{
			get => state;
			set
			{
				state = value;
				switch (state)
				{
					case TypewriterState.Completed:
						typewriter.CompleteOutput();
						break;
				}
			}
		}
		#endregion

		DialogNode DialogDat;

		public Sprite[] protaits;
		public string[] names;
		public string[] dialogueLines;
		bool haveSprite;
		bool isLeft;
		public int size;

		public GameObject LeftDialog;
		public GameObject RightDialog;
		public GameObject Dialog;

		GameObject NameText;
		GameObject ContentText;
		GameObject Head;

		int currentIndex = 0;


		
		/// <summary>
		/// 初始化UIDialog
		/// </summary>
		/// <param name="temp">DialogNode类的声明变量</param>
		public void InitDialog(DialogNode temp)
		{
			protaits = temp.protaits;
			names = temp.names;
			dialogueLines = temp.dialogueLines;
			haveSprite = temp.haveSprite;
			isLeft = temp.isLeft;
			size = temp.size;
			currentIndex = 0;

			OpenDialog();
		}

		private void OpenDialog()
		{
			this.gameObject.SetActive(false);
			if (haveSprite)
			{
				if (isLeft)
				{
					Head = LeftDialog.transform.Find("Head").gameObject;
					ContentText = LeftDialog.transform.Find("ContentText").gameObject;
					NameText = LeftDialog.transform.Find("NameText").gameObject;



					Head.GetComponent<Image>().sprite = protaits[currentIndex];
					ContentText.GetComponent<Text>().text = dialogueLines[currentIndex];
					NameText.GetComponent<Text>().text = names[currentIndex];
					LeftDialog.SetActive(true);
				}
				else
				{
					Head = LeftDialog.transform.Find("Head").gameObject;
					ContentText = LeftDialog.transform.Find("ContentText").gameObject;
					NameText = LeftDialog.transform.Find("NameText").gameObject;



					Head.GetComponent<Image>().sprite = protaits[currentIndex];
					ContentText.GetComponent<Text>().text = dialogueLines[currentIndex];
					NameText.GetComponent<Text>().text = names[currentIndex];
					RightDialog.SetActive(true);
				}
			}
			else
			{
				Head = LeftDialog.transform.Find("Head").gameObject;
				ContentText = LeftDialog.transform.Find("ContentText").gameObject;
				NameText = LeftDialog.transform.Find("NameText").gameObject;



				Head.GetComponent<Image>().sprite = protaits[currentIndex];
				ContentText.GetComponent<Text>().text = dialogueLines[currentIndex];
				NameText.GetComponent<Text>().text = names[currentIndex];
				Dialog.SetActive(true);
			}
			this.gameObject.SetActive(true);
		}

		public void PlayDialog()
        {
			if(size == 1) {
				BikManager.Instsance.gameMode = GameMode.GamePlay;
				return;
			}
			if(currentIndex == size - 1) {
				BikManager.Instsance.gameMode = GameMode.GamePlay;
				return;
			}
			currentIndex++;
			Head.GetComponent<Image>().sprite = protaits[currentIndex];
			ContentText.GetComponent<Text>().text = dialogueLines[currentIndex];
			NameText.GetComponent<Text>().text = names[currentIndex];
			OpenDialog();
		}
	}
}
