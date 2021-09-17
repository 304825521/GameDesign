//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace BehaviourMachine {

    /// <summary>
    /// Changes the text of a Text.
    /// </summary>
    [NodeInfo(  category = "Action/GUIElement/",
                icon = "Text",
                description = "Changes the text of a Text",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Text.html")]
    public class SetText : ActionNode {

        /// <summary>
        /// The game object that has a gui text in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a gui text in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The new text to display.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Change", tooltip = "The new text to display")]
        public StringVar newText;

        /// <summary>
        /// Append a float value to the text.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "Append a float value to the text")]
        public FloatVar appendFloat;

        /// <summary>
        /// Append an int value to the text.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "Append an int value to the text")]
        public IntVar appendInt;

        [System.NonSerialized]
        Text m_Text;

        public override void Reset () {
            newText = new ConcreteStringVar();
            appendFloat = new ConcreteFloatVar();
            appendInt = new ConcreteIntVar();
        }

        public override Status Update () {
            // Get the gui text
            if (m_Text == null || m_Text.gameObject != gameObject.Value)
                m_Text = gameObject.Value != null ? gameObject.Value.GetComponent<Text>() : null;

            // Validate members
            if (m_Text == null)
                return Status.Error;

            var text = string.Empty;

            // String
            if (!newText.isNone) text = newText.Value;

            // Float
            if (!appendFloat.isNone) text += appendFloat.Value;

            // Int
            if (!appendInt.isNone) text += appendInt.Value;

            // Set Text.text
            m_Text.text = text;

            return Status.Success;
        }
    }
}