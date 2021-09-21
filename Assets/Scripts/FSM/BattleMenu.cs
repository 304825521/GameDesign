using FS2.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.FSM.Battle
{
	public class BattleMenu : MonoBehaviour
	{
		UIBattle UIBattle;
        UICombat UICombat;
        UIChoice UIChoice;



		private void OnEnable()
		{
            
            OpenBattleUI();
        }
		private void OpenBattleUI()
		{
            UIBattle = Game.UI.Open<UIBattle>();
			if (UIBattle == null)
			{
                Debug.Log("没有加载UIBATTLE");
                return;
            }
            UIChoice = Game.UI.Get<UIChoice>();
        
            if(UIChoice == null)
			{
                Debug.Log("没有加载UICHOICE");
                return;
            }
            UIChoice.Show();
            UIChoice.CombatPressed += OnCombatClick;
            UIChoice.DefendPressed += OnDefendClick;
            UIChoice.RunPressed += OnQuitClick;
            UIChoice.AutoPressed += OnAutoClick;
            UIChoice.ToolsPressed += OnToolsClick;
            UIChoice.AttackPressed += OnAttackClick;
        }

        #region UIChoice的Action绑定
 
        public void OnCombatClick()
        {
            UICombat = Game.UI.Get<UICombat>();
            UIChoice.Hide();
            if (UICombat == null)
			{
                Debug.Log("没有获取到UICombat");
                return;
            }
            UICombat.Back += OpenBattleUI;
            UICombat.Show();
            
            
        }

        public void OnAttackClick()
        {
            //TODO:普通攻击的逻辑(未完善)
            BattleManager.Instsance.NormalAttackEnemy();
        }

        public void OnDefendClick()
        {
            //TODO:防御逻辑
        }

        public void OnQuitClick()
        {

            //TODO:逃走逻辑
        }

        public void OnAutoClick()
        {
 
            //TODO:自动攻击的逻辑
        }

        public void OnToolsClick()
        {

            //TODO:自动攻击的逻辑
        }

 
        #endregion

 
    }

}