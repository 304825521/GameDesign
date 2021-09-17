using BehaviourMachine;

namespace FS2.FSM.Main
{
	public class MainStateMachine : GameStateMachine
	{

		public new const string FINISHED = "FINISHED";
		protected override void OnEnableState(InternalStateBehaviour childState)
		{
			base.OnEnableState(childState);
		}

		protected override void OnDisableState(InternalStateBehaviour childState)
		{
			base.OnDisableState(childState);
		}
	}
}