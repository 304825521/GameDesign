using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FS2;
using FS2.Manager;
using FS2.Data;
using FS2.UI;
[System.Serializable]
public class DialogBehaviour : PlayableBehaviour
{
	private bool isClipPlayed; //是否完成Clip对话
	public bool requirePause = true; //用户设置，需要鼠标点击才能跳过
	private bool pauseScheduled;
	public Sprite[] protaits;
	public string[] names;
	[TextArea(1,3)]
	public string[] dialogueLines;
	public bool[] haveSprite;
	public bool[] isLeft;
	public int size;

	private PlayableDirector PlayableDirector;

	

	public override void OnPlayableCreate(Playable playable)
	{
		PlayableDirector = playable.GetGraph().GetResolver() as PlayableDirector;
	}

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		if (isClipPlayed == false && info.weight > 0)
		{
            DialogNode temp = new DialogNode(protaits, names, dialogueLines, haveSprite, isLeft, size);
            UIDialog UIDialog = Game.UI.Open<UIDialog>();
            UIDialog.InitDialog(temp);
			UIDialog.Hide();
            if (requirePause)
				pauseScheduled = true;
			isClipPlayed = true;
		}
	}

	public override void OnBehaviourPause(Playable playable, FrameData info)
	{
		isClipPlayed = false;
		if (pauseScheduled)
		{
			pauseScheduled = false;
			BikManager.Instsance.PauseTimeLineForBik();
		}
	}

}
