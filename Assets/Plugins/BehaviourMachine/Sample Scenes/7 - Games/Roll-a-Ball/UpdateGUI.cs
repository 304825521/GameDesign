using UnityEngine;
using System.Collections;
using BehaviourMachine;
using UnityEngine.UI;

namespace BehaviourMachine.Samples {
    public class UpdateGUI : StateBehaviour {

        public Text countText;
        public GameObject winText;

        IntVar m_Count;

        void Awake () {
            m_Count = blackboard.GetIntVar("Count");
        }

        void OnEnable () {
            countText.text = "Count: " + m_Count.Value.ToString();

            if (m_Count.Value >= 12)
                winText.SetActive(true);

            root.SendEvent(GlobalBlackboard.FINISHED);
        }
    }
}