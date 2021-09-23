using System.Collections.Generic;
using System.Linq;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using NodeCanvas.Framework;
using Logger = ParadoxNotion.Services.Logger;

namespace FlowCanvas.Nodes
{

    [Name("New Custom Function", 10)]
    [Description("A custom function, defined by any number of parameters and an optional return value. It can be called using the 'Call Custom Function' node. To end the function and optionally return a value, the 'Return' node should be used.")]
    [Category("Functions/Custom")]
    [ParadoxNotion.Serialization.DeserializeFrom("FlowCanvas.Nodes.RelayFlowOutput")]
    public class CustomFunctionEvent : EventNode, IInvokable, IEditorMenuCallbackReceiver
    {

        [DelayedField, Tooltip("The identifier name of the function")]
        //SL--
        public BBParameter<string> identifier = "MyFunction";
        [SerializeField]
        private List<DynamicParameterDefinition> _parameters = new List<DynamicParameterDefinition>();
        [SerializeField]
        private DynamicParameterDefinition _returns = new DynamicParameterDefinition("Value", null);

        private object[] args;
        private object returnValue;
        private FlowOutput onInvoke;

        ///the parameters port definition
        public List<DynamicParameterDefinition> parameters {
            get { return _parameters; }
            private set { _parameters = value; }
        }

        ///the return port definition
        public DynamicParameterDefinition returns {
            get { return _returns; }
            private set { _returns = value; }
        }

        //shortcut
        private System.Type returnType {
            get { return returns.type; }
        }

        //shortcut
        private System.Type[] parameterTypes {
            get { return parameters.Select(p => p.type).ToArray(); }
        }

        //SL--
        public override string name
        {
            get { return "➥ " + identifier.value; }
        }
        public override void OnGraphStoped() {
            returnValue = null;
            args = null;
        }

        protected override void RegisterPorts() {
            onInvoke = AddFlowOutput(" ");
            for ( var _i = 0; _i < parameters.Count; _i++ ) {
                var i = _i;
                var parameter = parameters[i];
                AddValueOutput(parameter.name, parameter.ID, parameter.type, () => { return args[i]; });
            }
        }

        //SL--
        string IInvokable.GetInvocationID() { return identifier.value; }
        object IInvokable.Invoke(params object[] args) { return Invoke(new Flow(), args); }
        void IInvokable.InvokeAsync(System.Action<object> callback, params object[] args) {
            InvokeAsync(new Flow(), (f) => { callback(returnValue); }, args);
        }


        ///Invokes the function and return it's return value
        public object Invoke(Flow f, params object[] args) {
            this.args = args;
            FlowReturn returnCallback = (o) => { this.returnValue = o; };
            var invocationFlow = new Flow();
            invocationFlow.SetReturnData(returnCallback, returns.type);
            onInvoke.Call(invocationFlow);
            return returnValue;
        }

        ///Invokes the function and callbacks when a Return node is hit.
        public void InvokeAsync(Flow f, FlowHandler flowCallback, params object[] args) {
            this.args = args;
            FlowReturn returnCallback = (o) => { this.returnValue = o; flowCallback(f); };
            var invocationFlow = new Flow();
            invocationFlow.SetReturnData(returnCallback, returns.type);
            onInvoke.Call(invocationFlow);
        }

        ///Returns the function's last return value
        public object GetReturnValue() {
            return returnValue;
        }

        //Add a parameter to the function
        void AddParameter(System.Type type) {
            parameters.Add(new DynamicParameterDefinition(type.FriendlyName(), type));
            GatherPortsUpdateRefs();
        }

        //Helper
        void GatherPortsUpdateRefs() {
            this.GatherPorts();
            foreach ( var call in flowGraph.GetAllNodesOfType<CustomFunctionCall>().Where(n => n.sourceFunction == this) ) {
                call.GatherPorts();
            }
        }

        ///----------------------------------------------------------------------------------------------
        ///---------------------------------------UNITY EDITOR-------------------------------------------
#if UNITY_EDITOR

        void IEditorMenuCallbackReceiver.OnMenu(UnityEditor.GenericMenu menu, Vector2 pos, Port contextPort, object dropInstance) {
            if ( contextPort != null ) {
                if ( contextPort is ValueInput && !contextPort.type.IsAssignableFrom(returnType) ) { return; }
                if ( contextPort is ValueOutput && !parameterTypes.Any(t => t.IsAssignableFrom(contextPort.type)) ) { return; }
            }
            menu.AddItem(new GUIContent(string.Format("Functions/Custom/Call '{0}()'", identifier)), false, () =>
           {
               flowGraph.AddFlowNode<CustomFunctionCall>(pos, contextPort, dropInstance).SetFunction(this);
           });
        }
        //SL--
        ///Adds a new input port definition to the Macro
        public bool AddInputDefinition(DynamicParameterDefinition def)
        {
            if (parameters.Find(d => d.ID == def.ID) == null)
            {
                parameters.Add(def);
                return true;
            }
            return false;
        }
        //SL--
        protected override UnityEditor.GenericMenu OnDragAndDropPortContextMenu(UnityEditor.GenericMenu menu, Port port)
        {
            if (port is ValueInput)
            {
                menu.AddItem(new GUIContent(string.Format("Promote to new Input '{0}'", port.name)), false, () =>
                {
                    var def = new DynamicParameterDefinition(port.name, port.type);
                    if (AddInputDefinition(def))
                    {
                        GatherPorts();
                        BinderConnection.Create(GetOutputPort(def.ID), port);
                    }
                });
            }
            return menu;
        }
        string renameString;
        Dictionary<Graph, List<FunctionCall>> callFunctionNodeDict = new Dictionary<Graph, List<FunctionCall>>();
        Dictionary<Graph, List<CustomFunctionCall>> callCustomFunctionNodeDict = new Dictionary<Graph, List<CustomFunctionCall>>();
        Dictionary<Graph, List<FunctionCallSync>> callFunctionSyncNodeDict = new Dictionary<Graph, List<FunctionCallSync>>();
        protected override void OnNodeInspectorGUI() {
            base.OnNodeInspectorGUI();

            if ( GUILayout.Button("Add Parameter") ) {
                EditorUtils.ShowPreferedTypesSelectionMenu(typeof(object), (t) => { AddParameter(t); });
            }

            UnityEditor.EditorGUI.BeginChangeCheck();

            var options = new EditorUtils.ReorderableListOptions();
            options.allowRemove = true;
            EditorUtils.ReorderableList(parameters, options, (i, r) =>
            {
                var parameter = parameters[i];
                GUILayout.BeginHorizontal();
                parameter.name = UnityEditor.EditorGUILayout.DelayedTextField(parameter.name, GUILayout.Width(150), GUILayout.ExpandWidth(true));
                EditorUtils.ButtonTypePopup("", parameter.type, (t) => { parameter.type = t; GatherPortsUpdateRefs(); });
                GUILayout.EndHorizontal();
            });

            EditorUtils.Separator();

            EditorUtils.ButtonTypePopup("Return Type", returns.type, (t) => { returns.type = t; GatherPortsUpdateRefs(); });

            if ( UnityEditor.EditorGUI.EndChangeCheck() ) {
                GatherPortsUpdateRefs();
            }
        }

#endif
        ///----------------------------------------------------------------------------------------------
    }
}