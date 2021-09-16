using UnityEngine.EventSystems;
// Heluo.Game
namespace FS2.UI
{

	public abstract class UIWidget : UIBehaviour
	{

		public virtual void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public virtual void Show()
		{
			base.gameObject.SetActive(value: true);
		}
	}

}