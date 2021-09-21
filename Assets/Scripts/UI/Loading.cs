using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.UI
{
	public class Loading : MonoSingleton<Loading>
	{
		public Action Compelete;


		public void OnAfterLoadingComplete()
		{
			Debug.Log("Loading进度条满了");
			Compelete?.Invoke();
		}


	}
}
