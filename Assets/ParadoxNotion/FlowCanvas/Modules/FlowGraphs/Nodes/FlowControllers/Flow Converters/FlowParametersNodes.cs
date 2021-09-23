using ParadoxNotion.Design;
using System.Linq;
using UnityEngine;

//SL--
namespace FlowCanvas.Nodes
{

    [Name("Read Flow Param")]
    [Category("Flow Controllers/Flow Convert")]
    [Description("Reads a named parameter from the incomming Flow and returns it's value.\nFlow parameters can be set with a WriteFlowParameter node.\nFlow parameters are temporary variables that exist only in the context of the same Flow.")]
    [ContextDefinedInputs(typeof(Wild))]
    [ContextDefinedOutputs(typeof(Wild))]
    public class ReadFlowParameter<T> : FlowControlNode
    {
        public override string name { get { return string.Format("{0}<{1}>({2})", base.name, typeof(T).Name, ParameterName); } }
        private T flowValue;
        private bool usePortValue;
        [SerializeField]
        private string ParameterName;
        ValueInput<string> pName;
        protected override void RegisterPorts()
        {
            var o = AddFlowOutput("Out");

            AddFlowInput("In", (f) =>
            {
                if (usePortValue)
                    ParameterName = pName.value;
                flowValue = f.ReadParameter<T>(ParameterName);
                o.Call(f);
            });

            if (usePortValue)
                pName = AddValueInput<string>("Name");
            AddValueOutput<T>("Value", () => { return flowValue; });
        }

#if UNITY_EDITOR

        protected override void OnNodeInspectorGUI()
        {
            if (usePortValue != GUILayout.Toggle(usePortValue, "UsePortValue"))
            {
                usePortValue = !usePortValue;
                GatherPorts();
            }
            if (usePortValue)
            {
                base.OnNodeInspectorGUI();
            }
            else
            {
                var relayInputs = graph.GetAllNodesOfType<WriteFlowParameter<T>>().Select(x => x.pName.value).ToList();
                if (relayInputs == null || relayInputs.Count < 1)
                    return;
                var currentInput = ParameterName;
                var newInput = EditorUtils.Popup<string>("ParameterName:", currentInput, relayInputs);
                if (newInput != currentInput)
                    ParameterName = newInput;
            }
        }
#endif
    }

    [Name("Write Flow Param")]
    [Category("Flow Controllers/Flow Convert")]
    [Description("Writes (or creates) a named parameter to the incomming Flow, which you can later read with a ReadFlowParameter node.\nFlow parameters are temporary variables that exist only in the context of the same Flow.")]
    [ContextDefinedInputs(typeof(Wild))]
    public class WriteFlowParameter<T> : FlowControlNode
    {
        public override string name { get { return string.Format("{0}<{1}>", base.name, typeof(T).Name); } }
        public ValueInput<string> pName;
        protected override void RegisterPorts()
        {
            var o = AddFlowOutput("Out");
            pName = AddValueInput<string>("Name");
            var pValue = AddValueInput<T>("Value");
            AddFlowInput("In", (f) =>
            {
                f.WriteParameter<T>(pName.value, pValue.value);
                o.Call(f);
            });
        }
    }
}