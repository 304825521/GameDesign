using FS2.FSM.Battle;
using FS2.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FS2;
public class test : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			BattleManager.Instsance.Bik02Battle();

		}


		if (Input.GetKeyDown(KeyCode.A))
		{
			UIBattle uIBattle = Game.UI.Open<UIBattle>();

		}

	}
}
