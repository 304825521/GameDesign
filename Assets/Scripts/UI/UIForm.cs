using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FS2.UI
{
    public class UIForm : UIBehaviour
    {
		public UIForm.Depth depth;

		internal UIManager UI { get { return Game.UI; } }

		public enum Depth
		{
			Back,
			Middle,
			Front,
			World
		}

        protected override void Awake()
        {
			Game.UI.Add(this);
        }

        protected override void OnDestroy()
        {
			Game.UI.Remove(this);
        }

        public virtual void Hide()
		{
			GameObject gameObject = base.gameObject;
			if (gameObject == null)
			{
				return;
			}
			gameObject.SetActive(false);
		}

		public virtual void Show()
		{
			GameObject gameObject = base.gameObject;
			if (gameObject == null)
			{
				return;
			}
			gameObject.SetActive(true);
		}

		public virtual void Close()
		{
			this.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
