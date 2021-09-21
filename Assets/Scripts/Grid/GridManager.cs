using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FS2.Utility;
using FS2.Data;

namespace FS2.Grid
{
    public class GridManager : MonoSingleton<GridManager>
    {
        UIDynamic UIDynamic;

        public GameObject GridPrefab;
        public GameObject PlayerGrid;
        public GameObject EnemyGrid;


        float offsetX = 0.75f;
        float offsetY = 0.4f;
        float offsetUp = -0.7f;
        public int distance = 6;
  

        Dictionary<string, GameObject> GridDictionarys;

        public List<GameObject> EnemyGrids = new List<GameObject>();
        public List<GameObject> PlayerGrids = new List<GameObject>();

        private void OnEnable()
        {
            GridDictionarys = new Dictionary<string, GameObject>();
        }


        #region 创造网格系统的相关代码
        /// <summary>
        /// 创造一个战斗网格
        /// </summary>
        /// <param name="vector">生成网格的位置</param>
        public void CreateGrid(Vector2 vector)
        {
          
            this.transform.position = vector;
            //创立玩家网格
            CreatePlayerGrid(PlayerGrid.transform);
            //创立敌人网格
            CreateEnemyGrid(EnemyGrid.transform);
        }

        private void CreateEnemyGrid(Transform EnemyGrid)
        {
            Vector2 Origin = Vector2.zero;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Origin = new Vector2(offsetX * j + offsetUp * i, offsetY * j + offsetY * i);
                    GameObject obj = new GameObject(i + "-" + j);
                    obj.transform.SetParent(EnemyGrid);
                    obj.transform.localPosition = Origin;
                    EnemyGrids.Add(obj);

                    GameObject temp = Instantiate<GameObject>(GridPrefab, obj.transform);
                    temp.SetActive(false);
                    temp.name = "Grid";

                }
            }
        }

        private void CreatePlayerGrid(Transform PlayerGrid)
        {
            Vector2 Origin = Vector2.zero;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Origin = new Vector2(offsetX * j + offsetUp * i, offsetY * j + offsetY * i);
                    GameObject obj = new GameObject(i + "-" + j);
                    obj.transform.SetParent(PlayerGrid);
                    obj.transform.localPosition = Origin;
                    PlayerGrids.Add(obj);

                    GameObject temp = Instantiate<GameObject>(GridPrefab, obj.transform);
                    temp.SetActive(false);
                    temp.name = "Grid";
                }
            }
        }
        #endregion

        public void PlaceUnitInGrid(Unit unit, string locationName)
		{

            if(unit.gameObject.tag == "Enemy")
			{
				for (int i = 0; i < EnemyGrids.Count; i++)
				{
                    if(EnemyGrids[i].name == locationName)
					{
                        unit.transform.SetParent(EnemyGrids[i].transform);
                        unit.transform.localPosition = Vector3.zero;
					}
				}
			}

            else if (unit.gameObject.tag == "Player")
            {
                for (int i = 0; i < PlayerGrids.Count; i++)
                {
                    if (PlayerGrids[i].name == locationName)
					{

						unit.transform.SetParent(PlayerGrids[i].transform);
                        unit.transform.localPosition = Vector3.zero;
                    }
				}
            }
        }

    }

}