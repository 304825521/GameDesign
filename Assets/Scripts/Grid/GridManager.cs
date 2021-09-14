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

        private void OnEnable()
        {
            // MapData mapData = new MapData();
            GridDictionarys = new Dictionary<string, GameObject>();
            //TODO:将来要从别的地方读取不同的地图的GridManager的tranform该给CreateGrid
            CreateGrid();

        }


        #region 网格系统的相关代码
        /// <summary>
        /// 创造一个战斗网格
        /// </summary>
        /// <param name="targetPos">生成网格的位置</param>
        /// <param name="distance">敌人和玩家的距离</param>
        public void CreateGrid()
        {
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
                    GameObject temp = Instantiate<GameObject>(GridPrefab, obj.transform);
                    temp.SetActive(false);
                    temp.name = "Grid";

                }
            }
        }
        #endregion
    }

}