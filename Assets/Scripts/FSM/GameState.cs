	using System;
	using BehaviourMachine;
namespace FS2.FSM
{

	public abstract class GameState<T> : StateBehaviour where T : GameStateMachine
	{
		internal new T fsm => base.fsm as T;

		public bool SendEvent(int eventId, EventArgs e)
		{
			fsm.eventArgs = e;
			return SendEvent(eventId);
		}

		public bool SendEvent(string eventName, EventArgs e)
		{
			fsm.eventArgs = e;
			return SendEvent(eventName);
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}