using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace FlowCanvas.Nodes
{
    [Color("a13574")]
    [Description("Encapsulates a SubGraph able to control independently.")]
    ///Base class for nested subgraphs that work a specific way, thus why it is separate than FlowNodeNested super base
    abstract public class FlowNestedBase<T> : FlowNodeNested<T>, IDropedReferenceNode, IUpdatable where T : Graph
    {

        public BBParameter<T> _subGraph;

        public override T subGraph { get { return _subGraph.value; } set { _subGraph.value = value; } }
        public override BBParameter subGraphParameter => _subGraph;

        private ValueInput<Component> targetAgent;

        private FlowOutput onStart;
        private FlowOutput onUpdate;
        private FlowOutput onFinish;

        //we need to keep track of pause call separately than sugraph.isPaused
        //so that step through debug works correctly
        private bool paused;
        private bool endResult;

        void IDropedReferenceNode.SetTarget(Object target) {
            _subGraph.value = target as T;
        }

        protected override void RegisterPorts() {
            targetAgent = AddValueInput<Component>("Agent");
            AddFlowInput("Start", Start);
            AddFlowInput("Stop", Stop);
            AddFlowInput("Pause", Pause);
            AddFlowInput("Resume", Resume);

            onStart = AddFlowOutput("Start");
            onUpdate = AddFlowOutput("Update");
            onFinish = AddFlowOutput("Finish");

            AddValueOutput<float>("Runtime", () => currentInstance.elapsedTime);
            AddValueOutput<bool>("Result", () => endResult);
        }

        void Start(Flow f) {
            paused = false;
            status = Status.Running;
            this.TryStartSubGraph(targetAgent.value, (result) => { endResult = result; OnStop(f); });
            //SL--
            f.Call(onStart);
        }

        void Stop(Flow f) {
            this.TryStopSubGraph();
        }

        void OnStop(Flow f) {
            status = Status.Resting;
            f.Call(onFinish);
        }

        void Pause(Flow f) {
            paused = true;
            this.TryPauseSubGraph();
        }

        void Resume(Flow f) {
            paused = false;
            this.TryResumeSubGraph();
            //SL--
            f.Call(onStart);
        }

        void IUpdatable.Update() {
            if ( !paused && this.TryUpdateSubGraph() ) {
                OnAfterUpdateCall();
                //we check isRunning for in case the subgraph was JUST finished due to this update call
                if ( currentInstance.isRunning ) {
                    onUpdate.Call(new Flow());
                }
            }
        }

        //...
        virtual protected void OnAfterUpdateCall() { }
        //SL--
        ////////////////////////////////////////
        ///////////GUI AND EDITOR STUFF/////////
        ////////////////////////////////////////
#if UNITY_EDITOR
        string newSubGraphName = "";
        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();

            if (_subGraph.value == null)
            {
                return;
            }

            //---------------------更新Asset资源名称
            newSubGraphName = UnityEditor.EditorGUILayout.TextField("newSubGraphName", newSubGraphName);

            if (!Application.isPlaying && GUILayout.Button("RefreshSubGraphName"))
            {
                _subGraph.value.name = newSubGraphName;
                if (UnityEditor.AssetDatabase.IsMainAsset(_subGraph.value) || UnityEditor.AssetDatabase.IsSubAsset(_subGraph.value))
                    UnityEditor.AssetDatabase.ImportAsset(UnityEditor.AssetDatabase.GetAssetPath(_subGraph.value));
            }
        }
#endif
    }
}