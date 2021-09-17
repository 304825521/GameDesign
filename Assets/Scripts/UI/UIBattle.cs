using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{

    public class UIBattle : UIForm
    {
        CtrlBattle controller;

        public override void Show()
        {
            if(this.controller == null)
            {
                this.controller = new CtrlBattle(this);
            }
            base.Show();
        } 

    }
}