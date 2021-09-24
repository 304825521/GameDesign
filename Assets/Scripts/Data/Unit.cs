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
		private bool isAction = false;
		//该单位是否已经死亡
		bool isDead = false;	

		public UIDynamic UIDynamic;

		GameObject GridObj;
		GameObject BaseObj;

        private void OnEnable()
        {
			InitDataFromCharcterData();
		}

        public CharacterData CharacterData;

		public bool IsAction { get => isAction; set => isAction = value; }
		public bool IsDead { get => isDead; set => isDead = value; }

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
