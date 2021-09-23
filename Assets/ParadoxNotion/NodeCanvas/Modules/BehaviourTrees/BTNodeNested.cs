using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.BehaviourTrees
{
    [Category("SubGraphs")]
    [Color("a13574")]
    abstract public class BTNodeNested<T> : BTNode, IGraphAssignable<T> where T : Graph
    {
        [SerializeField] private List<BBMappingParameter> _variablesMap;

        abstract public T subGraph { get; set; }
        abstract public BBParameter subGraphParameter { get; }

        public T currentInstance { get; set; }
        public Dictionary<Graph, Graph> instances { get; set; }
        public List<BBMappingParameter> variablesMap { get { return _variablesMap; } set { _variablesMap = value; } }

        Graph IGraphAssignable.subGraph { get { return subGraph; } set { subGraph = (T)value; } }
        Graph IGraphAssignable.currentInstance { get { return currentInstance; } set { currentInstance = (T)value; } }

        //SL--
        ////////////////////////////////////////
        ///////////GUI AND EDITOR STUFF/////////
        ////////////////////////////////////////
#if UNITY_EDITOR
        string newSubGraphName = "";
        protected override void OnNodeInspectorGUI()
        {
            base.OnNodeInspectorGUI();

            if (subGraph == null)
            {
                return;
            }

            //---------------------更新Asset资源名称
            newSubGraphName = UnityEditor.EditorGUILayout.TextField("newSubGraphName", newSubGraphName);

            if (!Application.isPlaying && GUILayout.Button("RefreshSubGraphName"))
            {
                subGraph.name = newSubGraphName;
                if (UnityEditor.AssetDatabase.IsMainAsset(subGraph) || UnityEditor.AssetDatabase.IsSubAsset(subGraph))
                    UnityEditor.AssetDatabase.ImportAsset(UnityEditor.AssetDatabase.GetAssetPath(subGraph));
            }
        }
#endif
    }
}