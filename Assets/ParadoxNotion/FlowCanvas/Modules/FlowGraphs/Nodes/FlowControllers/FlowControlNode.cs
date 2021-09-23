using ParadoxNotion.Design;

namespace FlowCanvas.Nodes
{

    [Category("Flow Controllers")]
    [Color("7d6d5a")]
    [ContextDefinedInputs(typeof(Flow))]
    [ContextDefinedOutputs(typeof(Flow))]
    abstract public class FlowControlNode : FlowNode { }
}