using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("My Nodes")]
	[Icon("SomeIcon")]
	[Description("Some description")]
	public class NodeName : BTNode
	{

		//When the BT starts
		public override void OnGraphStarted()
		{
			
		}

		//When the BT stops
		public override void OnGraphStoped()
		{

		}

		//When the BT pauses
		public override void OnGraphPaused()
		{

		}

		//When the node is Ticked
		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{

			return Status.Success;
		}

		//When the node resets (start of graph, interrupted, new tree traversal).
		protected override void OnReset()
		{

		}

#if UNITY_EDITOR

		//This GUI is shown IN the node IF you want
		protected override void OnNodeGUI()
		{

		}

		//This GUI is shown when the node is selected IF you want
		protected override void OnNodeInspectorGUI()
		{

			DrawDefaultInspector(); //this is done when you dont override this method anyway.
		}

#endif
	}
}