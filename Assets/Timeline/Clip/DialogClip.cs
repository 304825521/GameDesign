using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogClip : PlayableAsset
{
	public DialogBehaviour template = new DialogBehaviour();

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		var playable = ScriptPlayable<DialogBehaviour>.Create(graph, template);
		DialogBehaviour clone = playable.GetBehaviour();
		return playable;
	}
}
