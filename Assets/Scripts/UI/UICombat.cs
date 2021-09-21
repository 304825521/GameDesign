using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace FS2.UI
{
    public class UICombat : UIForm
    {
		public Action Back;
		public GameObject Base;

		public override void Show()
		{
			base.Show();
			Base.SetActive(true);
			//TODO:
			InitCombatData();


		}
		protected override void OnEnable()
		{
			GameManager.Status = GameManager.GameStatus.OnSkillPannel;
		}
		private void Update()
		{
			if(GameManager.Status == GameManager.GameStatus.OnSkillPannel)
			{
				if(Input.GetMouseButtonDown(1))
				{
					this.Hide();
					Back?.Invoke();
					GameManager.Status = GameManager.GameStatus.Normal;
				}
			}
		}

		public void InitCombatData()
		{

		}

		
	}
}