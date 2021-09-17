//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace BehaviourMachine {

    /// <summary>
    /// Changes the color of a Text.
    /// </summary>
    [NodeInfo(  category = "Action/GUIElement/",
                icon = "Text",
                description = "Changes the color of a Text",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Text.html")]
    public class SetTextColor : ActionNode {

        /// <summary>
        /// The game object that has a gui text in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a gui text in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The new text color.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Change",tooltip = "The new text color")]
        public ColorVar newColor;

        [System.NonSerialized]
        Text m_Text;

        public override void Reset () {
            newColor = new ConcreteColorVar();
        }

        public override Status Update () {
            // Get the gui text
            if (m_Text == null || m_Text.gameObject != gameObject.Value)
                m_Text = gameObject.Value != null ? gameObject.Value.GetComponent<Text>() : null;

            // Validate members
            if (m_Text == null)
                return Status.Error;

            // Set Color
            #if !UNITY_4_0_0 && !UNITY_4_1
            if (!newColor.isNone) m_Text.color = newColor.Value;
            #else
            if (!newColor.isNone) m_Text.material.color = newColor.Value;
            #endif

            return Status.Success;
        }
    }
}