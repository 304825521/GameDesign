﻿using FS2.FSM.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

namespace FS2.Data
{
	public class EnemyUnit : Unit
	{
		public bool canAttack = false;
		public bool finishAttack = true;
		int countForEndGame = 0;
		public override void StartBattle()
		{
			//TODO:开始AI的攻击逻辑
			if (canAttack == false) { return; }
			
			if (countForEndGame == 3)
			{
				//TODO:结束战斗开始剧情
				Debug.Log("游戏到此为止");
				return;
				
			}
			countForEndGame++;
			FindPlayer();
		}

		public void FindPlayer()
		{
			finishAttack = false;
			//1.找到玩家并且判断哪个玩家血比较少，攻击血少的
			Unit Defend = null ;
			
			for (int i = 0; i < BattleManager.Instsance.PlayerList.Count; i++)
			{
				if (BattleManager.Instsance.PlayerList.Count == 1)
				{
					Defend = BattleManager.Instsance.PlayerList[0];
					if (Defend.IsDead) return;
					if (Defend.IsAction) return;
					AttackPlayer(Defend);
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
			//4. 开始攻击 这里就要确定是否是技能攻击或者正常攻击了
			NormalAttack(OriginPosition, attackPoint, m_Player.position,this, Defend);
		}

		

		public void NormalAttack(Vector3 OriginPosition, Vector3 attackPoint, Vector3 Player,Unit Attack, Unit Defend)
		{
			//1. 需要Defend的单位不再行动
			StartCoroutine(WaitAttack(Defend));
			Attack.transform.DOMove(Player - attackPoint, 0.4f)
				.OnUpdate(() =>
				{
					UIDynamic.Play("JumpTo");
				})
				.OnComplete(async () =>
				{
					UIDynamic.Play("Attack");
					await Task.Delay(700);
					BattleManager.Instsance.HurtManager(Attack, Defend);
					Attack.transform.DOMove(OriginPosition, 0.4f)
						.OnUpdate(() =>
						{
							UIDynamic.Play("JumpBack");
						})
						.OnComplete(() =>
						{
							UIDynamic.Play("Idle");
							finishAttack = false;
						});

				});
		}

		IEnumerator WaitAttack(Unit defend)
        {
			yield return new WaitUntil(() => defend.IsAction == false);
		}


	}
}


