using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace FS2.UI
{
	public class WGBtn : UIWidget, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler
	{
		[Serializable]
		public class TriggerEvent : UnityEvent<BaseEventData>
		{
		}

		public TriggerEvent PointerEnter;

		public TriggerEvent PointerExit;

		public TriggerEvent PointerClick;

		public TriggerEvent PointerDown;

		public TriggerEvent PointerUp;

		public TriggerEvent Select;

		public TriggerEvent Deselect;

		public TriggerEvent Submit;

		public TriggerEvent Cancel;

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				PointerEnter?.Invoke(eventData);
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				PointerExit?.Invoke(eventData);
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				PointerDown?.Invoke(eventData);
			}
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			if (Cursor.visible)
			{
				PointerUp?.Invoke(eventData);
			}
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (Cursor.visible && eventData.button != PointerEventData.InputButton.Right)
			{
				PointerClick?.Invoke(eventData);
			}
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
			Select?.Invoke(eventData);
		}

		public virtual void OnDeselect(BaseEventData eventData)
		{
			Deselect?.Invoke(eventData);
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			Submit?.Invoke(eventData);
		}

		public virtual void OnCancel(BaseEventData eventData)
		{
			Cancel?.Invoke(eventData);
		}
	}
}
