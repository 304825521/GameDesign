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

		public float ExistTime = 3f;

		public Rigidbody2D Rigidbody2D;
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
				Third.GetComponent<Image>().sprite = ThirdSprite;
				Third.SetActive(true);
				JumpAnim();
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
                	Third.GetComponent<Image>().sprite = ThirdSprite;
                        Second.GetComponent<Image>().sprite = SecondSprite;
                        Third.SetActive(true);
                        Second.SetActive(true);
				Rigidbody2D.AddForce(new Vector2(-0.5f, 2f));
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
				Third.GetComponent<Image>().sprite = ThirdSprite;
				Second.GetComponent<Image>().sprite = SecondSprite;
				First.GetComponent<Image>().sprite = SecondSprite;
				Third.SetActive(true);
				Second.SetActive(true);
				First.SetActive(true);
				JumpAnim();
			}
		}

		public void SetDamageNumberByChars(char[] vs)
        {
			if(vs.Length == 1)
            {
                Sprite ThirdSprite = null;
                switch (vs[0])
                {
					case '0':
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;
				}
                Third.GetComponent<Image>().sprite = ThirdSprite;
                Third.SetActive(true);
                JumpAnim();
            }
            else if (vs.Length==2)
			{
				Sprite ThirdSprite = null;
				Sprite SecondSprite = null;

				switch (vs[1])
				{
					case '0':
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;

				}
				switch (vs[0])
				{

					case '0':
						SecondSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						SecondSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						SecondSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						SecondSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						SecondSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						SecondSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						SecondSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						SecondSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						SecondSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						SecondSprite = GameManager.GamePrefab.FN09;
						break;
				}
				Third.GetComponent<Image>().sprite = ThirdSprite;
				Second.GetComponent<Image>().sprite = SecondSprite;
				Third.SetActive(true);
				Second.SetActive(true);
				JumpAnim();
			}
			else if (vs.Length==3)
			{
				Sprite ThirdSprite = null;
				Sprite SecondSprite = null;
				Sprite FirstSprite = null;
				switch (vs[3])
				{
					case '0':
						ThirdSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						ThirdSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						ThirdSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						ThirdSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						ThirdSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						ThirdSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						ThirdSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						ThirdSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						ThirdSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						ThirdSprite = GameManager.GamePrefab.FN09;
						break;
				}
				switch (vs[2])
				{
					case '0':
						SecondSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						SecondSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						SecondSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						SecondSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						SecondSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						SecondSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						SecondSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						SecondSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						SecondSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						SecondSprite = GameManager.GamePrefab.FN09;
						break;
				}

				switch (vs[0])
				{
					case '0':
						FirstSprite = GameManager.GamePrefab.FN00;
						break;
					case '1':
						FirstSprite = GameManager.GamePrefab.FN01;
						break;
					case '2':
						FirstSprite = GameManager.GamePrefab.FN02;
						break;
					case '3':
						FirstSprite = GameManager.GamePrefab.FN03;
						break;
					case '4':
						FirstSprite = GameManager.GamePrefab.FN04;
						break;
					case '5':
						FirstSprite = GameManager.GamePrefab.FN05;
						break;
					case '6':
						FirstSprite = GameManager.GamePrefab.FN06;
						break;
					case '7':
						FirstSprite = GameManager.GamePrefab.FN07;
						break;
					case '8':
						FirstSprite = GameManager.GamePrefab.FN08;
						break;
					case '9':
						FirstSprite = GameManager.GamePrefab.FN09;
						break;
				}
				Third.GetComponent<Image>().sprite = ThirdSprite;
				Second.GetComponent<Image>().sprite = SecondSprite;
				First.GetComponent<Image>().sprite = SecondSprite;
				Third.SetActive(true);
				Second.SetActive(true);
				First.SetActive(true);
				JumpAnim();
			}

		}

        private void JumpAnim()
        {
            Vector3 target = new Vector3(this.transform.localPosition.x- 3f, this.transform.localPosition.y + 2f);
			this.transform.DOJump(target, 2f, 1, 3f)
				.OnComplete(() => {
					this.Hide();
				});
        }

        public void SetParent(Transform transform)
        {
			this.transform.SetParent(transform,false);
			this.gameObject.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
			this.gameObject.transform.localPosition = Vector3.zero;
		}


	}
}