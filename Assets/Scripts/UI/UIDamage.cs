using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace FS2.UI
{
	public class UIDamage : UIForm
	{
		public GameObject First;
		public GameObject Second;
		public GameObject Third;
		public override void Show()
		{
			
			base.Show();
		}

		public void SetDamageNumber(int third, int second = -1, int first = -1)
		{
			if (second == -1 && first == -1 && third != -1)
			{
				Sprite ThirdSprite = null;
				switch (third)
				{
					case 0:
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;
				}
			}

			else if (first == -1 && second != -1 && third != -1)
			{
				Sprite ThirdSprite = null;
				Sprite SecondSprite = null;

				switch (third)
				{
					case 0:
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;
				}
				switch (second)
				{
					case 0:
						SecondSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						SecondSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						SecondSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						SecondSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						SecondSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						SecondSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						SecondSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						SecondSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						SecondSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						SecondSprite = GameManager.GamePrefab.FN09;
						break;
				}
		/*		ThirdNum.GetComponent<Image>().sprite = ThirdSprite;
				SecondNum.GetComponent<Image>().sprite = SecondSprite;
				ThirdNum.SetActive(true);
				SecondNum.SetActive(true);*/
			}
			else if (first != -1 && second != -1 && third != -1)
			{
				Sprite ThirdSprite = null;
				Sprite SecondSprite = null;
				Sprite FirstSprite = null;
				switch (third)
				{
					case 0:
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;
				}
				switch (second)
				{
					case 0:
						SecondSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						SecondSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						SecondSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						SecondSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						SecondSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						SecondSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						SecondSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						SecondSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						SecondSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						SecondSprite = GameManager.GamePrefab.FN09;
						break;
				}

				switch (first)
				{
					case 0:
						FirstSprite = GameManager.GamePrefab.FN00;
						break;
					case 1:
						FirstSprite = GameManager.GamePrefab.FN01;
						break;
					case 2:
						FirstSprite = GameManager.GamePrefab.FN02;
						break;
					case 3:
						FirstSprite = GameManager.GamePrefab.FN03;
						break;
					case 4:
						FirstSprite = GameManager.GamePrefab.FN04;
						break;
					case 5:
						FirstSprite = GameManager.GamePrefab.FN05;
						break;
					case 6:
						FirstSprite = GameManager.GamePrefab.FN06;
						break;
					case 7:
						FirstSprite = GameManager.GamePrefab.FN07;
						break;
					case 8:
						FirstSprite = GameManager.GamePrefab.FN08;
						break;
					case 9:
						FirstSprite = GameManager.GamePrefab.FN09;
						break;
				}
	/*			ThirdNum.GetComponent<Image>().sprite = ThirdSprite;
				SecondNum.GetComponent<Image>().sprite = SecondSprite;
				FirstNum.GetComponent<Image>().sprite = SecondSprite;
				ThirdNum.SetActive(true);
				SecondNum.SetActive(true);
				FirstNum.SetActive(true);*/
			}
		}

	}
}