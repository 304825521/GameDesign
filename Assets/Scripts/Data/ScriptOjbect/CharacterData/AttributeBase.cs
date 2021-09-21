using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FS2.Data
{
	[CreateAssetMenu(fileName = "Data", menuName = "Charactrer/Data")]
	public class AttributeBase : ScriptableObject
	{
		[Header("最高属性")]

		public int maxHp;
		public int maxMp;
		public int maxlevel;
		public int maxSkillNumber;
		public int maxExp;

		[Header("Status Info")]
		public int strength;
		public int abilityPower;
		public int strong;
		public int magicResistance;
		public int speed;


		[Header("当前的状态的值")]
		public int currentHp;
		public int currentMp;
		public int currentDefence;
		public int currentAttack;
		public int currentlevel;
		public int maxskillNumber;

		[Header("基础属性")]
		public int attack;
		public int defence;
		public int currentExp;
	}
}
