using FS2.FSM.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.Data
{
	public class EnemyUnit : Unit
	{
		
		public override void StartBattle()
		{
			//TODO:开始AI的攻击逻辑
			//1. wait攻击顺序4s
			//2. 
		}

		public void FindPlayer()
		{

			//1.找到玩家并且判断哪个玩家血比较少，攻击血少的
			Unit Defend;
			for (int i = 0; i < BattleManager.Instsance.PlayerList.Count; i++)
			{
				if (BattleManager.Instsance.PlayerList.Count == 1)
				{
					Defend = BattleManager.Instsance.PlayerList[0];
				}
				else
				{
					//TODO:有多个玩家的时候的AI寻找逻辑
				}
			}
		}

		public void AttackPlayer(Unit Defend)
		{
			//1. 记录自己位置
			Vector3 OriginPosition = GetComponentInParent<Transform>().transform.position;
			//2. 寻找当前玩家的grid位置
			Transform m_Player = Defend.GetComponentInParent<Transform>();
			//3. 计算攻击点
			Vector3 attackPoint = m_Player.position - OriginPosition;
			attackPoint.Normalize();
			//4. 开始攻击

		}


	}
}
