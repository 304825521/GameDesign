namespace FS2.FSM
{
	using System;
	using BehaviourMachine;

	public abstract class GameStateMachine : StateMachine
	{
		public const string FINISHED = "FINISHED";

		internal EventArgs eventArgs { get; set; }

		public bool SendEvent(int eventId, EventArgs e)
		{
			eventArgs = e;
			return SendEvent(eventId);
		}

		public bool SendEvent(string eventName, EventArgs e)
		{
			eventArgs = e;
			return SendEvent(eventName);
		}
	}
}