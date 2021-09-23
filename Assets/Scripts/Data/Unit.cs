using FS2.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.Data
{
	public class Unit : MonoBehaviour
	{
		public string unitName;
		//该单位是否在行动
		protected bool isAction = false;
		
		public UIDynamic UIDynamic;

		GameObject GridObj;
		GameObject BaseObj;

        private void OnEnable()
        {
			InitDataFromCharcterData();
		}

        public CharacterData CharacterData;

		/// <summary>
        /// 初始化敌人的基本属性
        /// </summary>
		public void InitDataFromCharcterData()
        {
			CharacterData.CurrentHp = CharacterData.MaxHp;
			CharacterData.CurrentMp = CharacterData.MaxMp;
			CharacterData.CurrentAttack = CharacterData.Attack;
			CharacterData.CurrentDefence = CharacterData.Defence;
			CharacterData.CurrentHp = CharacterData.MaxHp;
		}

		/// <summary>
		/// 开启战斗顺序进度条
		/// </summary>
		public virtual void StartBattle()
		{
			UIBattle Battle = Game.UI.Get<UIBattle>();
			Battle.StartLoading(unitName);
		}
	}
}
