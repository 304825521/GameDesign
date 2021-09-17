using System;

namespace FS2.UI
{
    public class UIChoice : UIForm
    {
        public Action CombatPressed;
        public Action DefendPressed;
        public Action RunPressed;
        public Action AutoPressed;
        public Action ToolsPressed;
        public Action AttackPressed;

        public void OnCombatPressed()
        {
            
            CombatPressed?.Invoke();
        }

        public void OnDefendPressed()
        {
            DefendPressed?.Invoke();
        }

        public void OnAttackPressed()
        {
            AttackPressed?.Invoke();
        }

        public void OnToolsPressed()
        {
            ToolsPressed?.Invoke();
        }

        public void OnRunPressed()
        {
            RunPressed?.Invoke();
        }

        public void OnAutoPressed()
        {
            AutoPressed?.Invoke();
        }
    }
}