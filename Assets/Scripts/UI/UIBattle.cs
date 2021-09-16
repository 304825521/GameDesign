using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{
    enum BattleStage
    {
        Normal,
        Choice,
        Attack,
        Combat,

    }
    public class UIBattle : UIForm
    {
        CtrlBattle controller;

        //默认当前的操作的是正常状态
        BattleStage battleStage = BattleStage.Normal;

        [SerializeField]
        UICombat combat;

        [SerializeField]
        UIBattleStatus battleStatus;

        [SerializeField]
        UIChoice choice;



        public override void Show()
        {
            if(this.controller == null)
            {
                this.controller = new CtrlBattle(this);
            }
            base.Show();
        }

        /// <summary>
        /// 点击Combat按钮后的事件
        /// </summary>
        public void OnCombatClick()
        {
            choice.Hide();
            combat.Show();
        }

        public void OnAttackClick()
        {
            choice.Hide();
            //TODO:普通攻击的逻辑
        }

        public void OnDefendClick()
        {
            choice.Hide();
            //TODO:防御逻辑
        }

        public void OnQuitClick()
        {
            this.Close();
            //TODO:逃走逻辑
        }

        public void onAutoClick()
        {
            choice.Hide();
            //TODO:自动攻击的逻辑
        }
        
    }
}