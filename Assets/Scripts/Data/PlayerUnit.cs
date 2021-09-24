using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.Data
{
	public class PlayerUnit : Unit
	{
        private void Update()
        {
            switch (CharacterData.fsm)
            {
                case FSM.GetHurt:
                    UIDynamic.Play("GetHurt");
                    break;
                case FSM.Dead:
                    UIDynamic.Play("Dead");
                    IsDead = true;
                    break;
                default:        
                    break;
            }
        }
    }
}
