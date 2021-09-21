using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.Data
{
	public class EnemyUnit : Unit
	{
		public override void StartBattle()
		{
			Debug.Log("敌人不像玩家这样调用StartBattle");
		}
	}
}
