using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS2.Data
{
	public class DialogNode
	{

		public Sprite[] protaits;
		public string[] names;
		public string[] dialogueLines;
		public bool haveSprite;
		public bool isLeft;
		public int size;

		public DialogNode(Sprite[] protaits, string[] names, string[] dialogueLines, bool haveSprite, bool isLeft, int size)
		{
			this.protaits = protaits;
			this.names = names;
			this.dialogueLines = dialogueLines;
			this.haveSprite = haveSprite;
			this.isLeft = isLeft;
			this.size = size;
		}
	}

}