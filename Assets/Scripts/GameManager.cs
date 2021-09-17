using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
	/// <summary>
	/// 游戏全局变量
	/// </summary>
	public enum GameStatus
	{
		OnSkillPannel,
		Normal,
		
	}
	public static GamePrefab GamePrefab;

	public static GameStatus Status = GameStatus.Normal;
	protected override void Awake()
	{
		base.Awake();
		GamePrefab = Resources.Load<GamePrefab>("Prefabs/GamePrefab");
		if(GamePrefab==null)
		{
			Debug.Log("GamePrefab不存在，请检查下目录是否有它");
		}
	}


}
