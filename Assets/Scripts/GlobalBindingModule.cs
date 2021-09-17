using FS2.UI;
using Ninject.Modules;

using System;

namespace FS2
{
	public class GlobalBindingModule : NinjectModule
	{
		public override void Load()
		{
			Bind<DialogManager>().ToSelf().InSingletonScope();
			Bind<UIManager>().ToSelf().InSingletonScope();
			Bind<AudioPlayer>().ToSelf().InSingletonScope();
		}

	}
}