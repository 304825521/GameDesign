using ParadoxNotion.Design;
using System.Collections.Generic;
using System.Linq;
//SL--
namespace FlowCanvas.Nodes
{
    [Color("000000")]
    [Name("FlowRemoteDummy", 100)]
    [Description("Use for flow organization.")]
    [ContextDefinedInputs(typeof(Flow))]
    [ContextDefinedOutputs(typeof(Flow))]
    public class Dummy : FlowControlNode
    {
        public override string name { get { return null; } }
        protected override void RegisterPorts()
        {
            var fOut = AddFlowOutput(" ", "Out");//不要更改 In 或Out的名字
            AddFlowInput(" ", "In", (f) => { fOut.Call(f); });
        }
    }
    [Color("000000")]
    [Name("ValueRemoteDummy", 99)]
    [Category("Flow Controllers")]
    [Description("Use for value organization.")]
    [ContextDefinedInputs(typeof(object))]
    [ContextDefinedOutputs(typeof(object))]
    public class ValuePoint<T> : FlowNode
    {
        public override string name { get { return null; } }
        protected override void RegisterPorts()
        {
            var VI = AddValueInput<T>(" ", "In");  //不要更改 In 或Out的名字
            AddValueOutput<T>(" ", "Out", () => { return VI.value; });
        }

#if UNITY_EDITOR
        BinderConnection[] _GetInPortConnections(Port port)
        {
            return inConnections.Cast<BinderConnection>().Where(c => c.targetPort == port).ToArray();
        }

        //Get all output Connections of a port. Used only for when removing
        BinderConnection[] _GetOutPortConnections(Port port)
        {
            return outConnections.Cast<BinderConnection>().Where(c => c.sourcePort == port).ToArray();
        }

        public override void OnDestroy(bool isReplace)
        {
            base.OnDestroy(isReplace);
            if (GetInputPort("In").isConnected && GetOutputPort("Out").isConnected)
            {
                BinderConnection[] binderConnections = _GetInPortConnections(GetInputPort("In"));

                if (binderConnections == null || binderConnections.Length < 1)
                    return;
                Port sourcePort = binderConnections[0].sourcePort;
                foreach (var c in binderConnections)
                {
                    graph.RemoveConnection(c);
                }

                binderConnections = _GetOutPortConnections(GetOutputPort("Out"));
                List<object> temp = new List<object>();
                binderConnections.ForEach((x) => { temp.Add(x.targetPort); });
                graph.tempPorts = temp;

                foreach (var c in binderConnections)
                {
                    graph.RemoveConnection(c);
                }

                foreach (var p in graph.tempPorts)
                {
                    Port targetPort = (Port)p;
                    //UnityEngine.Debug.Log("!"+sourcePort.connections);
                    BinderConnection.Create(sourcePort, targetPort);
                }
                graph.tempPorts = null;
            }
            //}

        }
#endif
    }
}