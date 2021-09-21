using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPannel : MonoBehaviour
{
	private string nameOpenPannel;
	public string NameOpenPannel { get => nameOpenPannel; set => nameOpenPannel = value; }

	public void OpenPannel(string name)
	{
		NameOpenPannel = name;
		gameObject.SetActive(true);
	}
}
