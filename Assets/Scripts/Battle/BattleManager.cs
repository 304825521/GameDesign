using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using FS2.UI;
using FS2.Utility;
using FS2.Grid;
using FS2.Data;
using System;
using DG.Tweening;
namespace FS2.FSM.Battle{
    public class BattleManager : MonoSingleton<BattleManager>
    {
		GameObject Map;
		GameObject GridObj;
		GameObject BattleMenu;
		UIBattle UIBattle;

		//存储当前战斗的玩家人数
		public List<Unit> PlayerList = new List<Unit>();
		//存储当前战斗的敌人人数
		public List<Unit> EnemyList = new List<Unit>();

		protected override void Awake()
		{
			base.Awake();
			Map = this.gameObject.transform.Find("Map").gameObject;
			if(Map == null)
			{
				Debug.Log("没有加载Map这个GameObject");
			}
			GridObj = this.gameObject.transform.Find("GridManager").gameObject;
			if (GridObj == null)
			{
				Debug.Log("没有加载GridManager这个GameObject");
			}
		}
		/// <summary>
		/// 剧情战和英招
		/// </summary>
		public void Bik02Battle()
		{
			ClearList();
			InitBattle01Map();
			InitGrid();
			OpenBattleUI();
			CreateCharacter();
		}

		#region 初始化

		private void ClearList()
		{
			PlayerList.Clear();
			EnemyList.Clear();
		}
		private void OpenBattleUI()
		{
			BattleMenu = transform.Find("BattleMenu").gameObject;
			BattleMenu.SetActive(true);
		}

		private void CreateCharacter()
		{
			//GameObject Player = Resources.Load<GameObject>("Prefabs/ChuGe");
			//GameObject YingZhao = Resources.Load<GameObject>("Prefabs/YingZhao");
			Unit Player = Instantiate(Resources.Load<GameObject>("Prefabs/ChuGe")).GetComponent<PlayerUnit>();
			Unit YingZhao = Instantiate(Resources.Load<GameObject>("Prefabs/YingZhao")).GetComponent<EnemyUnit>();
			PlayerList.Add(Player);
			EnemyList.Add(YingZhao);

			GridManager.Instsance.PlaceUnitInGrid(Player, "1-1");
			GridManager.Instsance.PlaceUnitInGrid(YingZhao, "0-2");

			Player.StartBattle();
			//YingZhao.StartBattle();
		}

		private void InitGrid()
		{
			GridObj.SetActive(true);
			//TODO:不过vector以后是要从特定文件中读取的
			Vector2 vector = new Vector2(1.15f, -3.52f);
			GridManager.Instsance.CreateGrid(vector);

		}

		private void InitBattle01Map()
		{
			Map.SetActive(true);
			Sprite sprite = Resources.Load<Sprite>("BattleMap/1-7");
			Map.GetComponent<SpriteRenderer>().sprite = sprite;

		} 
		#endregion

		public void NormalAttackEnemy()
		{
			//当前只有一个敌人
			if(EnemyList.Count == 1)
			{
				//0. 关闭攻击面板
				
				//1. 寻找当前敌人的grid位置 
				Transform m_Enemy = EnemyList[0].GetComponentInParent<Transform>();

				//2. 获得开启面板玩家的单位和
				Unit Player = GetPlayer();
				Vector3 origin = Player.GetComponentInParent<Transform>().transform.position;
				//3. 计算攻击点
				Vector3 attackPoint = EnemyList[0].transform.position - Player.gameObject.transform.position;
				attackPoint.Normalize();
				//4. 开始移动
				UIBattle.CloseUIAfterAttack?.Invoke();
				Player.transform.DOMove(EnemyList[0].transform.position - attackPoint, 0.4f)
					.OnUpdate(()=> {
						Player.UIDynamic.Play("JumpTo");
					})
					.OnComplete(async ()=> {
						Player.UIDynamic.Play("Attack");
						await Task.Delay(700);
						HurtManager(Player, EnemyList[0]);

						Player.transform.DOMove(origin, 0.4f)
									.OnUpdate(() => {
										Player.UIDynamic.Play("JumpBack");
									})
									.OnComplete(()=> {
										Player.UIDynamic.Play("Idle");
										UIBattle.ResetLoading?.Invoke();
									})
									;
					});
				
			}
		}

		public void HurtManager(Unit Attacker,Unit Defender)
		{
			float damage = Attacker.CharacterData.CurrentAttack - Defender.CharacterData.CurrentDefence;
			int realDamage = (int)UnityEngine.Random.Range(damage - 3f, damage + 3f);
            if(realDamage <= 0) { realDamage = 1; }
            char[] vs = Extensions.GetChars(realDamage);
			UIDamage uIDamage = Game.UI.Open<UIDamage>();
			uIDamage.SetDamageNumberByChars(vs);
			uIDamage.SetParent(Defender.transform);
			Defender.CharacterData.CurrentHp -= (int)realDamage;
			Defender.UIDynamic.Play("GetHurt");
		
			
		}

		public Unit GetPlayer()
		{
			UIBattle = Game.UI.Get<UIBattle>();
			string currentPlayerName = UIBattle.GetActionPannelName();
			for (int i = 0; i < PlayerList.Count; i++)
			{
				if(PlayerList[i].unitName == currentPlayerName)
				{
					return PlayerList[i];
				}
			}
			return null;
		}

		#region AILogic




		#endregion
	}

}