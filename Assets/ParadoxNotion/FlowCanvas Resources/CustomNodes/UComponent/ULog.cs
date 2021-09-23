﻿using System.Collections;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;



namespace FlowCanvas.Nodes
{
    #region Debug
    
    [Name("Debug(EditorMode)")]
    [Category("Events")]
    [Description("在编辑模式下触发运行一次")]
    public class ExecuteInEditModeEvent : EventNode
    {

        private FlowOutput fOut;
        protected override void RegisterPorts()
        {
            fOut = AddFlowOutput("Out");
        }


#if UNITY_EDITOR

        protected override void OnNodeInspectorGUI()
        {
            if (GUILayout.Button("Execute"))
            {   
                //if(!graph.isRunning)                  
                graph.agent.GetComponent<FlowScriptController>().StartBehaviour();
                //for (var i = 0; i < graph.allNodes.Count; i++)
                //{
                //    if (graph.allNodes[i] is FlowNode)
                //    {
                //        var flowNode = (FlowNode)graph.allNodes[i];
                //        flowNode.BindPorts();
                //        flowNode.AssignSelfInstancePort();
                //    }
                //}
                fOut.Call(new Flow());

                graph.agent.GetComponent<FlowScriptController>().StopBehaviour();
            }
        }

#endif
    }
    
    [Name("LogOnScreen")]
    [Category("UnityEngine/Debug")]
    [Description("物体在屏幕位置显示log,跟随物体屏幕位置,或固定在屏幕位置")]
    [ContextDefinedInputs(typeof(Flow),typeof(string))]
    public class G_LogOnScreen : FlowNode
    {
        [SerializeField]
        string log;
        public bool logOnFlowGraphConsole=true;
        public bool logOnUnityConsole = true;
        public float labelYOffset = 0;
        public float secondsToRun = 1f;
        private GameObject go;
        [SerializeField]
        private bool logOnScreen=true;

        [SerializeField]
        private Vector2 LogScreenRatio = new Vector2(0.1f,0.2f);

        public LogType logType = LogType.Log;

        [SerializeField]
        private bool hasPrefix = false;
        [SerializeField]
        string prefix="";
        [SerializeField]
        private bool hasSuffix = false;
        [SerializeField]
        string suffix="";

        protected override void RegisterPorts()
        {
            var transform = AddValueInput<Transform>("FollowObj");
            var logIn = AddValueInput<string>("value");            
            var outPut = AddFlowOutput("Out");

            AddFlowInput("In", (f) =>
            {
                go = transform.value.gameObject;
                log = prefix+logIn.value+suffix;

                if (logOnFlowGraphConsole){
                    switch(logType)
                    {
                        case LogType.Log:
                            ParadoxNotion.Services.Logger.Log(string.Format("(<b>{0}</b>) {1}", go.name, log), graph.name, this);
                            break;
                        case LogType.Warning:
                            ParadoxNotion.Services.Logger.LogWarning(string.Format("(<b>{0}</b>) {1}", go.name, log), graph.name, this);
                            break;
                        case LogType.Error:
                            ParadoxNotion.Services.Logger.LogError(string.Format("(<b>{0}</b>) {1}", go.name, log), graph.name, this);
                            break;
                        default:
                            ParadoxNotion.Services.Logger.Log(string.Format("(<b>{0}</b>) {1}", go.name, log), graph.name, this);
                            break;
                    }

                }
                if (logOnUnityConsole)
                    Debug.Log(string.Format("(<b>{0}</b>) {1}", go.name, log), graph);

                if (!updating)
                {
                    MonoManager.current.onGUI += OnGUI;
                    updating = true;
                    StartCoroutine(UnRegisterLog(secondsToRun));
                }
                outPut.Call(f);
            });

        }

        IEnumerator UnRegisterLog(float time)
        {
            yield return new WaitForSeconds(secondsToRun);
            MonoManager.current.onGUI -= OnGUI;
            updating = false;
        }

        private bool updating = false;

        ////////////////////////////////////////
        ///////////GUI AND EDITOR STUFF/////////
        ////////////////////////////////////////

        private Texture2D _tex;

        private Texture2D tex
        {
            get
            {
                if (_tex == null)
                {
                    _tex = new Texture2D(1, 1);
                    _tex.SetPixel(0, 0, Color.white);
                    _tex.Apply();
                }
                return _tex;
            }
        }

        void OnGUI()
        {

            if (Camera.main == null)
            {
                return;
            }

            var point = logOnScreen? new Vector3(LogScreenRatio.x,LogScreenRatio.y): Camera.main.WorldToScreenPoint(go.transform.position + new Vector3(0, labelYOffset, 0));
            var size = new GUIStyle("label").CalcSize(new GUIContent(log));
            var r = logOnScreen ? new Rect(LogScreenRatio.x* Screen.width-size.x*0.5f, LogScreenRatio.y * Screen.height, size.x + 10, size.y) : new Rect(point.x - size.x/2, Screen.height - point.y, size.x + 10, size.y);
            GUI.color = new Color(1f, 1f, 1f, 0.5f);
            GUI.DrawTexture(r, tex);
            GUI.color = new Color(0.2f, 0.2f, 0.2f, 1);
            r.x += 4;
            GUI.Label(r, log);
            GUI.color = Color.white;
        }

#if UNITY_EDITOR
        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();
            logOnScreen = GUILayout.Toggle(logOnScreen, "LogOnScreen");
            if (logOnScreen)
            {
                LogScreenRatio = UnityEditor.EditorGUILayout.Vector2Field("ScreenPositionRatio",LogScreenRatio);
            }

            hasPrefix = GUILayout.Toggle(hasPrefix, "Prefix");
            if(hasPrefix)
            {
                prefix = UnityEditor.EditorGUILayout.TextField("Prefix:", prefix);
            }
            hasSuffix = GUILayout.Toggle(hasSuffix, "Suffix");
            if (hasSuffix)
            {
                suffix = UnityEditor.EditorGUILayout.TextField("Suffix:", suffix);
            }
        }
#endif
    }

    [Name("debugGizmoLine")]
    [Category("UnityEngine/Debug")]
    [Description("物体在屏幕位置显示line,from positionA, to positionB")]
    [ContextDefinedInputs(typeof(Flow))]
    public class G_DrawLine : FlowNode
    {
        string log;
        public float labelYOffset = 0;
        private Vector3 screenLogPos;

        private Vector3 fromPos;
        private Vector3 toPos;
        private Color color;

        public override void OnGraphStarted()
        {
            base.OnGraphStarted();
            MonoManager.current.onGUI += OnGUI;
        }

        public override void OnGraphStoped()
        {
            base.OnGraphStarted();
            MonoManager.current.onGUI -= OnGUI;
        }

        protected override void RegisterPorts()
        {
            var logIn = AddValueInput<string>("logValue");

            var from = AddValueInput<Vector3>("from");
            var to = AddValueInput<Vector3>("to");
            var linecolor = AddValueInput<Color>("color");

            var outPut = AddFlowOutput("Out");

            AddFlowInput("In", (f) =>
            {
                log = logIn.value;

                fromPos = from.value;
                toPos = to.value;
                color = linecolor.value;

                Debug.DrawLine(fromPos, toPos, color);
                updating = true;
                outPut.Call(f);

            });

        }

        private bool updating = false;

        ////////////////////////////////////////
        ///////////GUI AND EDITOR STUFF/////////
        ////////////////////////////////////////

        private Texture2D _tex;

        private Texture2D tex
        {
            get
            {
                if (_tex == null)
                {
                    _tex = new Texture2D(1, 1);
                    _tex.SetPixel(0, 0, Color.white);
                    _tex.Apply();
                }
                return _tex;
            }
        }

        void OnGUI()
        {
            if(!updating)
                return;

            if (Camera.main == null)
            {
                return;
            }

            var point = Camera.main.WorldToScreenPoint(toPos + new Vector3(0, labelYOffset, 0));
            var size = new GUIStyle("label").CalcSize(new GUIContent(log));
            var r = new Rect(point.x - size.x / 2, Screen.height - point.y, size.x + 10, size.y);
            GUI.color = new Color(1f, 1f, 1f, 0.5f);
            GUI.DrawTexture(r, tex);
            GUI.color = new Color(0.2f, 0.2f, 0.2f, 1);
            r.x += 4;
            GUI.Label(r, log);
            GUI.color = Color.white;

            updating = false;
        }

#if UNITY_EDITOR

        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();

        }
#endif
    }

    #endregion
}