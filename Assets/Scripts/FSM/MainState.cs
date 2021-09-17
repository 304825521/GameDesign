using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using FS2.UI;

namespace FS2.FSM.Main
{
	public class MainState : GameState<MainStateMachine>
	{
		internal UIManager UI => Game.UI;
	}

}