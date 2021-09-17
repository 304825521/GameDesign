using FS2.Utility;
using Ninject;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FS2.UI
{
	public class UIManager : IInitializable
	{
		[Inject]
		public Transform Back { get; private set; }

		public Transform Middle { get; private set; }

		public Transform Front { get; private set; }

		public GameObject MainCanvas { get; private set; }

		public EventSystem EventSystem { get; private set; }

		Dictionary<Type, UIForm> dictionary = new Dictionary<Type, UIForm>();

		public void Initialize()
		{
			string text = "UI/MainCanvas";
			GameObject gameObject = Resources.Load<GameObject>(text);
			if (gameObject == null)
			{
				Debug.Log("没有找到主要的MainCanvas");
				return;
			}
			GameObject gameObject2 = gameObject.Instantiate<GameObject>();

			text = "UI/EventSystem";
			gameObject = Resources.Load<GameObject>(text);
			if (gameObject == null)
			{
				Debug.Log("没有找到EventSystem");
				return;
			}
			GameObject gameObject4 = gameObject.Instantiate<GameObject>();

			this.MainCanvas = gameObject2;
			this.EventSystem = gameObject4.GetComponent<EventSystem>();
			this.Back = this.MainCanvas.transform.GetChild(0);
			this.Middle = this.MainCanvas.transform.GetChild(1);
			this.Front = this.MainCanvas.transform.GetChild(2);
		}

		public void SetParent(Transform t, UIForm.Depth depth)
		{
			switch (depth)
			{
				case UIForm.Depth.Back:
					t.SetParent(this.Back, false);
					t.localScale = Vector3.one;
					return;
				case UIForm.Depth.Middle:
					t.SetParent(this.Middle, false);
					t.localScale = Vector3.one;
					return;
				case UIForm.Depth.Front:
					t.SetParent(this.Front, false);
					t.localScale = Vector3.one;
					return;
				case UIForm.Depth.World:
					t.SetParent(this.MainCanvas.transform, false);
					t.localScale = Vector3.one / 100f;
					return;
				default:
					return;
			}
		}

		public void Add(UIForm form)
        {
			Dictionary<Type, UIForm> obj = this.dictionary;
            lock (obj)
            {
				if (!this.dictionary.ContainsKey(form.GetType()) || !(this.dictionary[form.GetType()] != null))
				{
					if (!this.dictionary.ContainsKey(form.GetType()))
					{
						this.dictionary[form.GetType()] = form;
					}
					else
					{
						this.dictionary.Add(form.GetType(), form);
					}
				}
			}
        }


		public void Remove(UIForm form)
		{
			Dictionary<Type, UIForm> obj = this.dictionary;
            lock (obj)
            {
				this.dictionary.Remove(form.GetType());
            }
		}

		public T Get<T>() where T:UIForm
        {
			return this.Get(typeof(T)) as T;
        }

		public UIForm Get(Type type)
        {
			if(this.dictionary.ContainsKey(type))
            {
				return this.dictionary[type];
            }
			return null;
        }

		public T Open<T>() where T : UIForm
		{
			return this.Open(typeof(T)) as T;
		}

		public UIForm Open(Type type)
		{
			if (this.dictionary.ContainsKey(type) && this.dictionary[type] != null)
			{
				this.dictionary[type].transform.SetAsLastSibling();
				this.dictionary[type].Show();
				return this.dictionary[type];
			}
			GameObject gameObject = Resources.Load<GameObject>("UI/UIForm/" + type.Name);
			if (!gameObject)
			{
				Debug.Log("UI/UIForm下没有" + type.Name);
				return null;
			}
			gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			UIForm component = gameObject.GetComponent<UIForm>();
			if (!component)
			{
				return null;
			}
			this.SetParent(component.transform, component.depth);
			component.transform.SetAsLastSibling();
			component.Show();
			return component;
		}

		public void Close<T>() where T : UIForm
		{
			Type typeFromHandle = typeof(T);
			if (this.dictionary.ContainsKey(typeFromHandle) && this.dictionary[typeFromHandle] != null)
			{
				this.dictionary[typeFromHandle].Close();
				this.dictionary[typeFromHandle] = null;
			}
		}

		public void Hide<T>() where T : UIForm
		{
			Type typeFromHandle = typeof(T);
			this.Hide(typeFromHandle);
		}

		public void Hide(Type type)
		{
			if (this.dictionary.ContainsKey(type) && this.dictionary[type] != null)
			{
				this.dictionary[type].Hide();
			}
		}




	}

}