using System;
using UnityEngine;

namespace FS2.UI
{
    public class UIChoice : UIForm
    {
        public Action CombatPressed;
        public Action DefendPressed;
        public Action RunPressed;
        public Action AutoPressed;
        public Action ToolsPressed;
        public Action AttackPressed;

		public GameObject ActionPannel;

		#region 点击按钮的的事件
		public void OnCombatPressed()
		{

			CombatPressed?.Invoke();
		}

		public void OnDefendPressed()
		{
			DefendPressed?.Invoke();
		}

		public void OnAttackPressed()
		{
			AttackPressed?.Invoke();
		}

		public void OnToolsPressed()
		{
			ToolsPressed?.Invoke();
		}

		public void OnRunPressed()
		{
			RunPressed?.Invoke();
		}

		public void OnAutoPressed()
		{
			AutoPressed?.Invoke();
		} 
		#endregion

		/// <summary>
		/// 获取谁开启了攻击面板
		/// </summary>
		/// <returns></returns>
		public string GetNameOpenPannel()
		{
			return ActionPannel.GetComponent<ActionPannel>().NameOpenPannel;
		}

	}
}