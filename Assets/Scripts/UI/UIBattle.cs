﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{

    public class UIBattle : UIForm
    {
        CtrlBattle controller;
        public UIPerson UIPerson;
        public UIChoice UIChoice;

        public Action CompleteLoading;


        public override void Show()
        {
            if(this.controller == null)
            {
                this.controller = new CtrlBattle(this);
            }
            base.Show();
        } 

        /// <summary>
        /// 外部接口控制Loading的启动
        /// </summary>
        public void StartLoading(string name)
		{
            List<UICard> Cards = UIPerson.Cards;
			for (int i = 0; i < Cards.Count; i++)
			{
     
                if(Cards[i].isActiveAndEnabled && Cards[i].cardName == name)
				{
                    Cards[i].StartLoading();
                }
			}
		}

        /// <summary>
        /// 获取谁开启了攻击面板
        /// </summary>
        /// <returns>返回string姓名</returns>
        public string GetActionPannelName()
		{
            return UIChoice.GetNameOpenPannel();
        }            

    }
}