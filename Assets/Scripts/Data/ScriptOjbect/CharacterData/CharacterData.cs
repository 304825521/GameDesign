using FS2.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

namespace FS2.Data
{
	public enum FSM
	{
		Idle,
		Defend,
		Attack_Single,
		Skill,
		GetHurt,
		NormalAttack,
		Dead,
	}

	public class CharacterData : MonoBehaviour, INotifyPropertyChanged
	{
		public AttributeBase Attribute;

		

		public FSM fsm = FSM.Idle;

		public UIDynamic UIDynamic;

		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public void BackToIdle()
		{
			fsm = FSM.Idle;
		}

		#region Read Data from AttributeBase
		public int MaxHp
		{
			get { if (Attribute != null) return Attribute.maxHp; else return 0; }
			set
			{
				Attribute.maxHp = value;
				
			}
		}

		public int MaxMp
		{
			get { if (Attribute != null) return Attribute.maxMp; else return 0; }
			set
			{
				Attribute.maxMp = value;
				OnPropertyChanged("MaxMp");
			}
		}

		public int Maxlevel
		{
			get { if (Attribute != null) return Attribute.maxlevel; else return 0; }
			set { Attribute.maxlevel = value; }
		}

		public int MaxSkillNumber
		{
			get { if (Attribute != null) return Attribute.maxSkillNumber; else return 0; }
			set { Attribute.maxSkillNumber = value; }
		}

		public int Strength
		{
			get { if (Attribute != null) return Attribute.strength; else return 0; }
			set { Attribute.strength = value; }
		}

		public int AbilityPower
		{
			get { if (Attribute != null) return Attribute.abilityPower; else return 0; }
			set { Attribute.abilityPower = value; }
		}

		public int Strong
		{
			get { if (Attribute != null) return Attribute.strong; else return 0; }
			set { Attribute.strong = value; }
		}

		public int MagicResistance
		{
			get { if (Attribute != null) return Attribute.magicResistance; else return 0; }
			set { Attribute.magicResistance = value; }
		}

		public int Speed
		{
			get { if (Attribute != null) return Attribute.speed; else return 0; }
			set { Attribute.speed = value; }
		}

		public int Attack
		{
			get { if (Attribute != null) return Attribute.attack; else return 0; }
			set { Attribute.attack = value; }
		}

		public int Defence
		{
			get { if (Attribute != null) return Attribute.defence; else return 0; }
			set { Attribute.defence = value; }
		}

		public int CurrentHp
		{
			get { if (Attribute != null) return Attribute.currentHp; else return 0; }
			set
            {
				//if (CurrentHp == value) return;
				Attribute.currentHp = value;




				if (Attribute.currentHp <= 0)	
                {
					//TODO:这里将状态机转换成死亡的时候
					UIBattle BATTLE = Game.UI.Get<UIBattle>();
					BATTLE.PersonDead?.Invoke();
					Attribute.currentHp = 0;
					fsm = FSM.Dead;
                }

			}
		}

		public int CurrentMp
		{
			get { if (Attribute != null) return Attribute.currentMp; else return 0; }
			set { Attribute.currentMp = value; }
		}

		public int CurrentAttack
		{
			get { if (Attribute != null) return Attribute.currentAttack; else return 0; }
			set { Attribute.currentAttack = value; }
		}

		public int CurrentDefence
		{
			get { if (Attribute != null) return Attribute.currentDefence; else return 0; }
			set { Attribute.currentDefence = value; }
		}

		public int Currentlevel
		{
			get { if (Attribute != null) return Attribute.currentlevel; else return 0; }
			set { Attribute.currentlevel = value; }
		}

		public int MaxskillNumber
		{
			get { if (Attribute != null) return Attribute.maxskillNumber; else return 0; }
			set { Attribute.maxskillNumber = value; }
		}

		public int MaxExp
		{
			get { if (Attribute != null) return Attribute.maxExp; else return 0; }
			set 
			{
				Attribute.maxExp = value;
			}
		}

		public int CurrentExp
		{
			get { if (Attribute != null) return Attribute.currentExp; else return 0; }
			set { Attribute.currentExp = value; }
		}
	
		#endregion
	}
}
