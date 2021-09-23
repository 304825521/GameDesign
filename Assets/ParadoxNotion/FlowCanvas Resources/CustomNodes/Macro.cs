using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ParadoxNotion;

namespace FlowCanvas.Macros
{

    public class MacroGroup : Macro
    {
    
        ///Macros dont use blackboard overrides or blackboard variables parametrization
        public override bool allowBlackboardOverrides => true;


    }
}