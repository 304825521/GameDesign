using FlowCanvas;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlowCanvas.Nodes
{   
    [Name("TimeLine")]
    [Category("UnityEngine")]
    [ContextDefinedInputs(typeof(Flow),typeof(float))]
    [ContextDefinedOutputs(typeof(Flow), typeof(float))]
    public class UTimeLine : FlowNode
    {

        public override string name { get => string.Format("{0}({1})", base.name, (isReverse ? "Reverse" : "Forward"));set => base.name = value; }

        float evalValue;
        float _timer = 0;
        FlowOutput Finish;
        FlowOutput Update;
        Flow currentFlow;
        ValueInput<AnimationCurve> animCurve;
        ValueInput<float> timer;
        bool isUpdate = false;
        bool isReverse = false;
        protected override void RegisterPorts()
        {
            var OutPut = AddFlowOutput("Played");

            Update = AddFlowOutput("Update");
            var Paused = AddFlowOutput("Paused");
            var Resumed = AddFlowOutput("Resumed");
            var Stop = AddFlowOutput("Stopped");
            var Reversed = AddFlowOutput("Reversed");
            var Reseted = AddFlowOutput("Reset");
            Finish = AddFlowOutput("Finish");


            timer = AddValueInput<float>("time");
            animCurve = AddValueInput<AnimationCurve>("animCurve");

            AddValueOutput<float>("Value",()=> evalValue);
            AddValueOutput<float>("leftTime", () => _timer);

            AddValueOutput<bool>("IsReverse", () => isReverse);
            AddFlowInput("PlayForward", (f) =>
            {   
                if(isReverse)
                {
                    if (!isUpdate)
                        MonoManager.current.onUpdate += OnUpdate;

                    isUpdate = true;

                    isReverse = false;

                    //_clampTime = timer.value;
                    OutPut.Call(f);
                    currentFlow = f;
                }
                else
                {
                    if (isUpdate)
                        return;

                    isUpdate = true;
                    MonoManager.current.onUpdate += OnUpdate;

                    OutPut.Call(f);
                    currentFlow = f;
                }

                _timer = isReverse ? timer.value : 0;

            });

            AddFlowInput("Pause", (f) =>
            {
                if (!isUpdate)
                    return;

                isUpdate = false;
                MonoManager.current.onUpdate -= OnUpdate;
                Paused.Call(f);
            });

            AddFlowInput("Resume", (f) =>
            {
                if (isUpdate)
                    return;

                isUpdate = true;
                MonoManager.current.onUpdate += OnUpdate;
                Resumed.Call(f);
            });

            AddFlowInput("Stop", (f) =>
            {
                if (!isUpdate)
                    return;

                isUpdate = false;
                MonoManager.current.onUpdate -= OnUpdate;
                Stop.Call(f);
            });
            AddFlowInput("Reverse", (f) =>
            {
                if (isUpdate && isReverse)
                    return;

                isReverse = true;
                _timer = isReverse ? timer.value : 0;

                if (!isUpdate)
                    MonoManager.current.onUpdate += OnUpdate;

                isUpdate = true;
                Reversed.Call(f);
                currentFlow = f;


            });

            AddFlowInput("Reset", (f) =>
            {

                _timer = isReverse ? timer.value : 0 ;

                Reseted.Call(f);
                currentFlow = f;
            });

        }

        void OnUpdate()
        {   
            if(isReverse)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _timer += Time.deltaTime;
            }
            


            if ( isReverse? _timer< 0 : _timer > timer.value)
            {
                MonoManager.current.onUpdate -= OnUpdate;
                Finish.Call(currentFlow);

                isUpdate = false;
                _timer = isReverse ? timer.value : 0;

                evalValue = animCurve.value.Evaluate( isReverse ?  0 : timer.value);
            }
            else
            {
                evalValue = animCurve.value.Evaluate(_timer);
            }

            Update.Call(currentFlow);
        }
    }

}