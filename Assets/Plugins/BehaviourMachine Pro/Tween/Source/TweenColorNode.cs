using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Base class for tween color nodes.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Base class for tween color nodes")]
    public abstract class TweenColorNode : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The color to fade the object to.
        /// </summary>
        [VariableInfo(tooltip = "The color to fade the object to")]
        public ColorVar color;

        public Color currentColor {
            get {
                // Get the initial color
                GameObject target = gameObject.Value ?? self;
                
                if (target != null) {
                    Renderer renderer = target.GetComponent<Renderer>();
                    if (renderer != null)
                        return renderer.material.color;
                    else {
                        Texture Texture = target.GetComponent<Texture>();
                        if (target.GetComponent<Texture>() != null)
						{

						}
                          
                        else {
                            Text Text = target.GetComponent<Text>();
                            if (Text != null)
                                return Text.material.color;
                            else {
                                Light light = target.GetComponent<Light>();
                                if (light != null)
                                    return light.color;
                            }
                        }
                    }
                }

                return Color.white;
            }

            set {
                // Set the current to
                GameObject target = gameObject.Value ?? self;
                
                if (target != null) {
                    Renderer renderer = target.GetComponent<Renderer>();
                    if (renderer != null)
                        renderer.material.color = value;
                    else {
                        Texture Texture = target.GetComponent<Texture>();
                        if (Texture != null)
						{

						}
                        
                        else {
                            Text Text = target.GetComponent<Text>();
                            if (Text != null)
                                Text.material.color = value;
                            else {
                                Light light = target.GetComponent<Light>();
                                if (light != null)
                                    light.color = value;
                            }
                        }
                    }
                }
            }
        }

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            color = new ConcreteColorVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }
    }
}