using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FS2.Utility;

public class UIDynamic : UIBehaviour
{
    public bool isEnable = true;
    private Animator animator;

    public void Play(string parameter)
    {
        if(this.IsLoseSomething(parameter))
        {
            return;
        }
        this.animator.Play(parameter);
    }

    private bool IsLoseSomething(string parameter)
    {
        if(animator==null)
        {
            this.animator = base.GetComponent<Animator>();
        }
        return this.animator == null || !this.animator.isActiveAndEnabled || this.animator.runtimeAnimatorController == null || parameter.IsNullOrEmpty();
    }
}
