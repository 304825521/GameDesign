using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes
{
    [Color("000000")]
    abstract public class ParameterVariableNode : FlowNode
    {
        abstract public BBParameter parameter { get; }
    }
}